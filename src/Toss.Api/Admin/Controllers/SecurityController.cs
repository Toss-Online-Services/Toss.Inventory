using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Security;
using Nop.Services.Customers;
using Nop.Services.Security;
using Nop.Web.Framework.Menu;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.Security;
using ILogger = Nop.Services.Logging.ILogger;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;
        private readonly IPermissionService _permissionService;
        private readonly ISecurityModelFactory _securityModelFactory;
        private readonly IWorkContext _workContext;
        private readonly IXmlSiteMap _xmlSiteMap;

        private static readonly char[] _separator = { ',' };
        private static Dictionary<string, string> _menuSystemNames = new();

        #endregion

        #region Ctor

        public SecurityController(
            ICustomerService customerService,
            ILogger logger,
            IPermissionService permissionService,
            ISecurityModelFactory securityModelFactory,
            IWorkContext workContext,
            IXmlSiteMap xmlSiteMap)
        {
            _customerService = customerService;
            _logger = logger;
            _permissionService = permissionService;
            _securityModelFactory = securityModelFactory;
            _workContext = workContext;
            _xmlSiteMap = xmlSiteMap;
        }

        #endregion

        #region Methods

        [HttpGet("access-denied")]
        public async Task<IActionResult> AccessDenied(string pageUrl, string pageSystemNameKey)
        {
            if (!_menuSystemNames.Any())
            {
                await _xmlSiteMap.LoadFromAsync("~/Areas/Admin/sitemap.config");

                void FillSystemNames(SiteMapNode node)
                {
                    if (!string.IsNullOrEmpty(node.Url))
                        return;

                    if (!string.IsNullOrEmpty(node.ControllerName) && !string.IsNullOrEmpty(node.ActionName))
                    {
                        var key = $"{node.ControllerName}.{node.ActionName}";
                        _menuSystemNames[key] = node.SystemName;
                    }

                    foreach (var childNode in node.ChildNodes)
                        FillSystemNames(childNode);
                }

                FillSystemNames(_xmlSiteMap.RootNode);
            }

            var currentCustomer = await _workContext.GetCurrentCustomerAsync();
            var menuSystemName = _menuSystemNames.GetValueOrDefault(pageSystemNameKey, "Home");

            if (currentCustomer == null || await _customerService.IsGuestAsync(currentCustomer))
                await _logger.InformationAsync($"Access denied to anonymous request on {pageUrl}");
            else
                await _logger.InformationAsync($"Access denied to user #{currentCustomer.Id} '{currentCustomer.Email}' on {pageUrl}");

            return Ok(new { Message = "Access denied", MenuSystemName = menuSystemName });
        }

        [HttpPost("permission-category")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> PermissionCategory([FromBody] PermissionItemSearchModel searchModel)
        {
            var model = await _securityModelFactory.PreparePermissionItemListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpGet("permission-edit/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> PermissionEditPopup(int id)
        {
            var permissionRecord = await _permissionService.GetPermissionRecordByIdAsync(id);
            var model = await _securityModelFactory.PreparePermissionItemModelAsync(permissionRecord);
            return Ok(model);
        }

        [HttpPut("permission-edit")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> PermissionEditPopup([FromBody] PermissionItemModel model)
        {
            if (ModelState.IsValid)
            {
                var mapping = await _permissionService.GetMappingByPermissionRecordIdAsync(model.Id);

                var rolesForDelete = mapping.Where(p => !model.SelectedCustomerRoleIds.Contains(p.CustomerRoleId))
                    .Select(p => p.CustomerRoleId).ToList();

                var rolesToAdd = model.SelectedCustomerRoleIds.Where(p => mapping.All(m => m.CustomerRoleId != p)).ToList();

                foreach (var customerRoleId in rolesForDelete)
                    await _permissionService.DeletePermissionRecordCustomerRoleMappingAsync(model.Id, customerRoleId);

                foreach (var customerRoleId in rolesToAdd)
                    await _permissionService.InsertPermissionRecordCustomerRoleMappingAsync(new PermissionRecordCustomerRoleMapping
                    {
                        PermissionRecordId = model.Id,
                        CustomerRoleId = customerRoleId
                    });

                var permissionRecord = await _permissionService.GetPermissionRecordByIdAsync(model.Id);

                if (rolesForDelete.Any() || rolesToAdd.Any())
                    await _permissionService.UpdatePermissionRecordAsync(permissionRecord);

                model = await _securityModelFactory.PreparePermissionItemModelAsync(permissionRecord);
                return Ok(model);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("permission-categories")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> PermissionCategories([FromBody] PermissionCategorySearchModel searchModel)
        {
            var model = await _securityModelFactory.PreparePermissionCategoryListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpGet("permissions")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> Permissions()
        {
            var model = await _securityModelFactory.PreparePermissionConfigurationModelAsync(new PermissionConfigurationModel());
            return Ok(model);
        }

        #endregion
    }
}
