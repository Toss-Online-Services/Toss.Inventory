using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Services.Common;
using Nop.Services.Directory;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Directory;

namespace Nop.Web.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly ICountryModelFactory _countryModelFactory;
        private readonly ICountryService _countryService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStoreService _storeService;

        #endregion

        #region Ctor

        public CountryController(IAddressService addressService,
            ICountryModelFactory countryModelFactory,
            ICountryService countryService,
            ICustomerActivityService customerActivityService,
            IExportManager exportManager,
            IImportManager importManager,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStateProvinceService stateProvinceService,
            IStoreMappingService storeMappingService,
            IStoreService storeService)
        {
            _addressService = addressService;
            _countryModelFactory = countryModelFactory;
            _countryService = countryService;
            _customerActivityService = customerActivityService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _stateProvinceService = stateProvinceService;
            _storeMappingService = storeMappingService;
            _storeService = storeService;
        }

        #endregion

        #region Utilities

        private async Task UpdateLocalesAsync(Country country, CountryModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(country, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        private async Task SaveStoreMappingsAsync(Country country, CountryModel model)
        {
            country.LimitedToStores = model.SelectedStoreIds.Any();
            await _countryService.UpdateCountryAsync(country);

            var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(country);
            var allStores = await _storeService.GetAllStoresAsync();
            foreach (var store in allStores)
            {
                if (model.SelectedStoreIds.Contains(store.Id))
                {
                    if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                        await _storeMappingService.InsertStoreMappingAsync(country, store.Id);
                }
                else
                {
                    var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                    if (storeMappingToDelete != null)
                        await _storeMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
                }
            }
        }

        #endregion

        #region Countries

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var model = await _countryModelFactory.PrepareCountrySearchModelAsync(new CountrySearchModel());
            return Ok(model);
        }

        [HttpPost("CountryList")]
        public async Task<IActionResult> CountryList(CountrySearchModel searchModel)
        {
            var model = await _countryModelFactory.PrepareCountryListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CountryModel model)
        {
            if (ModelState.IsValid)
            {
                var country = model.ToEntity<Country>();
                await _countryService.InsertCountryAsync(country);

                await _customerActivityService.InsertActivityAsync("AddNewCountry",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCountry"), country.Id), country);

                await UpdateLocalesAsync(country, model);
                await SaveStoreMappingsAsync(country, model);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Countries.Added"));

                return Ok(country);
            }

            model = await _countryModelFactory.PrepareCountryModelAsync(model, null, true);
            return BadRequest(model);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] CountryModel model)
        {
            var country = await _countryService.GetCountryByIdAsync(model.Id);
            if (country == null) return NotFound();

            if (ModelState.IsValid)
            {
                country = model.ToEntity(country);
                await _countryService.UpdateCountryAsync(country);

                await _customerActivityService.InsertActivityAsync("EditCountry",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCountry"), country.Id), country);

                await UpdateLocalesAsync(country, model);
                await SaveStoreMappingsAsync(country, model);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Countries.Updated"));

                return Ok(country);
            }

            model = await _countryModelFactory.PrepareCountryModelAsync(model, country, true);
            return BadRequest(model);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null) return NotFound();

            try
            {
                if (await _addressService.GetAddressTotalByCountryIdAsync(country.Id) > 0)
                    throw new NopException("The country can't be deleted. It has associated addresses");

                await _countryService.DeleteCountryAsync(country);

                await _customerActivityService.InsertActivityAsync("DeleteCountry",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCountry"), country.Id), country);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Configuration.Countries.Deleted"));

                return NoContent();
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("PublishSelected")]
        public async Task<IActionResult> PublishSelected([FromBody] ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var countries = await _countryService.GetCountriesByIdsAsync(selectedIds.ToArray());
            foreach (var country in countries)
            {
                country.Published = true;
                await _countryService.UpdateCountryAsync(country);
            }

            return Ok(new { Result = true });
        }

        [HttpPost("UnpublishSelected")]
        public async Task<IActionResult> UnpublishSelected([FromBody] ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var countries = await _countryService.GetCountriesByIdsAsync(selectedIds.ToArray());
            foreach (var country in countries)
            {
                country.Published = false;
                await _countryService.UpdateCountryAsync(country);
            }

            return Ok(new { Result = true });
        }

        #endregion

        #region States / provinces

        [HttpGet("States")]
        public async Task<IActionResult> States([FromQuery] StateProvinceSearchModel searchModel)
        {
            var country = await _countryService.GetCountryByIdAsync(searchModel.CountryId);
            if (country == null) return NotFound();

            var model = await _countryModelFactory.PrepareStateProvinceListModelAsync(searchModel, country);
            return Ok(model);
        }

        [HttpGet("GetStatesByCountryId/{countryId}")]
        public async Task<IActionResult> GetStatesByCountryId(string countryId, [FromQuery] bool? addSelectStateItem, [FromQuery] bool? addAsterisk)
        {
            ArgumentException.ThrowIfNullOrEmpty(countryId);

            var country = await _countryService.GetCountryByIdAsync(Convert.ToInt32(countryId));
            var states = country != null
                ? (await _stateProvinceService.GetStateProvincesByCountryIdAsync(country.Id, showHidden: true)).ToList()
                : new List<StateProvince>();

            var result = states.Select(s => new { id = s.Id, name = s.Name }).ToList();
            if (addAsterisk == true) result.Insert(0, new { id = 0, name = "*" });
            else
            {
                var defaultLabel = country == null
                    ? (addSelectStateItem == true
                        ? await _localizationService.GetResourceAsync("Admin.Address.SelectState")
                        : await _localizationService.GetResourceAsync("Admin.Address.Other"))
                    : await _localizationService.GetResourceAsync("Admin.Address.Other");
                result.Insert(0, new { id = 0, name = defaultLabel });
            }

            return Ok(result);
        }

        #endregion

        #region Export / import

        [HttpGet("ExportCsv")]
        public async Task<IActionResult> ExportCsv()
        {
            var fileName = $"states_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}_{CommonHelper.GenerateRandomDigitCode(4)}.csv";
            var states = await _stateProvinceService.GetStateProvincesAsync(true);
            var result = await _exportManager.ExportStatesToTxtAsync(states);

            return File(Encoding.UTF8.GetBytes(result), MimeTypes.TextCsv, fileName);
        }

        //TODO:come back and fix for swaggerUI

        //[HttpPost("ImportCsv")]
        //public async Task<IActionResult> ImportCsv([FromBody] IFormFile importcsvfile)
        //{
        //    if (importcsvfile == null || importcsvfile.Length == 0)
        //    {
        //        _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.UploadFile"));
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        var count = await _importManager.ImportStatesFromTxtAsync(importcsvfile.OpenReadStream());
        //        _notificationService.SuccessNotification(string.Format(await _localizationService.GetResourceAsync("Admin.Configuration.Countries.ImportSuccess"), count));

        //        return Ok();
        //    }
        //    catch (Exception exc)
        //    {
        //        await _notificationService.ErrorNotificationAsync(exc);
        //        return BadRequest(exc.Message);
        //    }
        //}

        #endregion
    }
}
