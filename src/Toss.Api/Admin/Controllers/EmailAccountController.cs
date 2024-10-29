using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Messages;
using Nop.Core.Infrastructure;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Messages;

namespace Nop.Web.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class EmailAccountController : ControllerBase
    {
        #region Fields

        private const char SEPARATOR = '-';

        private readonly EmailAccountSettings _emailAccountSettings;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IEmailAccountModelFactory _emailAccountModelFactory;
        private readonly IEmailAccountService _emailAccountService;
        private readonly IEmailSender _emailSender;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly INopFileProvider _fileProvider;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public EmailAccountController(EmailAccountSettings emailAccountSettings,
            ICustomerActivityService customerActivityService,
            IEmailAccountModelFactory emailAccountModelFactory,
            IEmailAccountService emailAccountService,
            IEmailSender emailSender,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            INopFileProvider fileProvider,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            IWebHelper webHelper,
            IWorkContext workContext)
        {
            _emailAccountSettings = emailAccountSettings;
            _customerActivityService = customerActivityService;
            _emailAccountModelFactory = emailAccountModelFactory;
            _emailAccountService = emailAccountService;
            _emailSender = emailSender;
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _fileProvider = fileProvider;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _webHelper = webHelper;
            _workContext = workContext;
        }

        #endregion

        #region Utilities

        private async Task<string> PrepareOAuthUrlAsync(EmailAccount emailAccount)
        {
            if (string.IsNullOrEmpty(emailAccount.ClientSecret) || string.IsNullOrEmpty(emailAccount.ClientId))
                return string.Empty;

            var tokenFilePath = _fileProvider.MapPath(NopMessageDefaults.GmailAuthStorePath);
            var credentialRoot = _fileProvider.Combine(tokenFilePath, emailAccount.Email);

            var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = emailAccount.ClientId,
                    ClientSecret = emailAccount.ClientSecret
                },
                Scopes = NopMessageDefaults.GmailScopes,
                DataStore = new FileDataStore(credentialRoot, true),
                UserDefinedQueryParams = new Dictionary<string, string> { ["emailAccountId"] = emailAccount.Id.ToString() }
            });

            var redirectUri = Url.Action(nameof(AuthReturn), null, null, _webHelper.GetCurrentRequestProtocol());
            var authCode = new AuthorizationCodeWebApp(codeFlow, redirectUri, $"{emailAccount.Id}{SEPARATOR}");
            var authResult = await authCode.AuthorizeAsync(emailAccount.Email, CancellationToken.None);

            return authResult.RedirectUri?.ToString();
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        public async Task<IActionResult> List(bool showTour = false)
        {
            var model = await _emailAccountModelFactory.PrepareEmailAccountSearchModelAsync(new EmailAccountSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        public async Task<IActionResult> List(EmailAccountSearchModel searchModel)
        {
            var model = await _emailAccountModelFactory.PrepareEmailAccountListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("mark-as-default/{id}")]
        public async Task<IActionResult> MarkAsDefaultEmail(int id)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(id);
            if (emailAccount == null)
                return NotFound("Email account not found");

            _emailAccountSettings.DefaultEmailAccountId = emailAccount.Id;
            await _settingService.SaveSettingAsync(_emailAccountSettings);

            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmailAccountModel model)
        {
            if (ModelState.IsValid)
            {
                var emailAccount = model.ToEntity<EmailAccount>();
                emailAccount.Password = model.Password;

                await _emailAccountService.InsertEmailAccountAsync(emailAccount);
                return CreatedAtAction(nameof(List), new { id = emailAccount.Id }, emailAccount);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EmailAccountModel model)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(id);
            if (emailAccount == null)
                return NotFound("Email account not found");

            if (ModelState.IsValid)
            {
                emailAccount = model.ToEntity(emailAccount);
                await _emailAccountService.UpdateEmailAccountAsync(emailAccount);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("change-secret/{id}")]
        public async Task<IActionResult> ChangeSecret(int id, [FromBody] string newSecret)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(id);
            if (emailAccount == null)
                return NotFound("Email account not found");

            emailAccount.ClientSecret = newSecret;
            await _emailAccountService.UpdateEmailAccountAsync(emailAccount);

            return NoContent();
        }

        [HttpPut("change-password/{id}")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] string newPassword)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(id);
            if (emailAccount == null)
                return NotFound("Email account not found");

            emailAccount.Password = newPassword;
            await _emailAccountService.UpdateEmailAccountAsync(emailAccount);

            return NoContent();
        }

        [HttpPost("send-test-email")]
        public async Task<IActionResult> SendTestEmail([FromBody] EmailAccountModel model)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(model.Id);
            if (emailAccount == null)
                return NotFound("Email account not found");

            try
            {
                var store = await _storeContext.GetCurrentStoreAsync();
                var subject = $"{store.Name} - Testing email functionality";
                var body = "Email works fine.";

                await _emailSender.SendEmailAsync(emailAccount, subject, body, emailAccount.Email, emailAccount.DisplayName, model.SendTestEmailTo, null);
                return Ok("Test email sent successfully");
            }
            catch (Exception exc)
            {
                return StatusCode(500, new { message = exc.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emailAccount = await _emailAccountService.GetEmailAccountByIdAsync(id);
            if (emailAccount == null)
                return NotFound("Email account not found");

            await _emailAccountService.DeleteEmailAccountAsync(emailAccount);
            return NoContent();
        }

        [HttpGet("auth-return")]
        public async Task<IActionResult> AuthReturn(AuthorizationCodeResponseUrl authorizationCode)
        {
            if (string.IsNullOrEmpty(authorizationCode.State))
                return BadRequest("Invalid state parameter");

            var accountIdString = authorizationCode.State.Split(SEPARATOR).FirstOrDefault();

            if (!int.TryParse(accountIdString, out var accountId) ||
                await _emailAccountService.GetEmailAccountByIdAsync(accountId) is not EmailAccount emailAccount)
            {
                return NotFound("Email account could not be loaded");
            }

            if (!string.IsNullOrEmpty(authorizationCode.Error))
            {
                return BadRequest($"Authorization error: {authorizationCode.Error}");
            }

            if (string.IsNullOrEmpty(authorizationCode?.Code))
                return BadRequest("Authorization code is missing");

            var tokenFilePath = _fileProvider.MapPath(NopMessageDefaults.GmailAuthStorePath);
            var credentialRoot = _fileProvider.Combine(tokenFilePath, emailAccount.Email);

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = emailAccount.ClientId,
                    ClientSecret = emailAccount.ClientSecret
                },
                Scopes = NopMessageDefaults.GmailScopes,
                DataStore = new FileDataStore(credentialRoot, true)
            });

            var redirectUri = Url.Action(nameof(AuthReturn), null, null, _webHelper.GetCurrentRequestProtocol());
            var tokenResponse = await flow.ExchangeCodeForTokenAsync(emailAccount.Email, authorizationCode.Code, redirectUri, CancellationToken.None);

            return tokenResponse != null ? Ok("Token successfully retrieved") : StatusCode(500, "Failed to retrieve token");
        }

        #endregion
    }
}
