using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Stores;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Stores;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreModelFactory _storeModelFactory;
        private readonly IStoreService _storeService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public StoreController(
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreModelFactory storeModelFactory,
            IStoreService storeService,
            IGenericAttributeService genericAttributeService,
            IWebHelper webHelper,
            IWorkContext workContext)
        {
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeModelFactory = storeModelFactory;
            _storeService = storeService;
            _genericAttributeService = genericAttributeService;
            _webHelper = webHelper;
            _workContext = workContext;
        }

        #endregion

        #region Utilities

        private async Task UpdateLocalesAsync(Store store, StoreModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(store, x => x.Name, localized.Name, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(store, x => x.DefaultTitle, localized.DefaultTitle, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(store, x => x.DefaultMetaDescription, localized.DefaultMetaDescription, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(store, x => x.DefaultMetaKeywords, localized.DefaultMetaKeywords, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(store, x => x.HomepageDescription, localized.HomepageDescription, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(store, x => x.HomepageTitle, localized.HomepageTitle, localized.LanguageId);
            }
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_STORES)]
        public async Task<IActionResult> List()
        {
            var model = await _storeModelFactory.PrepareStoreSearchModelAsync(new StoreSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_STORES)]
        public async Task<IActionResult> List([FromBody] StoreSearchModel searchModel)
        {
            var model = await _storeModelFactory.PrepareStoreListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("create")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_STORES)]
        public async Task<IActionResult> Create([FromBody] StoreModel model)
        {
            if (ModelState.IsValid)
            {
                var store = model.ToEntity<Store>();
                if (!store.Url.EndsWith("/"))
                    store.Url += "/";

                await _storeService.InsertStoreAsync(store);
                await _customerActivityService.InsertActivityAsync("AddNewStore",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewStore"), store.Id), store);

                await UpdateLocalesAsync(store, model);
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Stores.Added"));

                return Ok(store);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("edit/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_STORES)]
        public async Task<IActionResult> Edit(int id, [FromBody] StoreModel model)
        {
            var store = await _storeService.GetStoreByIdAsync(id);
            if (store == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                store = model.ToEntity(store);
                if (!store.Url.EndsWith("/"))
                    store.Url += "/";

                await _storeService.UpdateStoreAsync(store);
                await _customerActivityService.InsertActivityAsync("EditStore",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditStore"), store.Id), store);

                await UpdateLocalesAsync(store, model);
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Stores.Updated"));

                return Ok(store);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("set-ssl/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_STORES)]
        public async Task<IActionResult> SetStoreSslByCurrentRequestScheme(int id)
        {
            var store = await _storeService.GetStoreByIdAsync(id);
            if (store == null)
                return NotFound();

            var value = _webHelper.IsCurrentConnectionSecured();
            if (store.SslEnabled != value)
            {
                store.SslEnabled = value;
                await _storeService.UpdateStoreAsync(store);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Stores.Ssl.Updated"));
            }

            return Ok(store);
        }

        [HttpDelete("delete/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_STORES)]
        public async Task<IActionResult> Delete(int id)
        {
            var store = await _storeService.GetStoreByIdAsync(id);
            if (store == null)
                return NotFound();

            try
            {
                await _storeService.DeleteStoreAsync(store);
                await _customerActivityService.InsertActivityAsync("DeleteStore",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteStore"), store.Id), store);

                var settingsToDelete = (await _settingService.GetAllSettingsAsync())
                    .Where(s => s.StoreId == id)
                    .ToList();
                await _settingService.DeleteSettingsAsync(settingsToDelete);

                var allStores = await _storeService.GetAllStoresAsync();
                if (allStores.Count == 1)
                {
                    settingsToDelete = (await _settingService.GetAllSettingsAsync())
                        .Where(s => s.StoreId == allStores[0].Id)
                        .ToList();
                    await _settingService.DeleteSettingsAsync(settingsToDelete);
                }

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Stores.Deleted"));

                return NoContent();
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return BadRequest(exc.Message);
            }
        }

        #endregion
    }
}
