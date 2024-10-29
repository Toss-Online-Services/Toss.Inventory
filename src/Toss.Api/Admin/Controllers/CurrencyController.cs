using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Directory;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Directory;

namespace Toss.Api.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyApiController : ControllerBase
{
    private readonly CurrencySettings _currencySettings;
    private readonly ICurrencyModelFactory _currencyModelFactory;
    private readonly ICurrencyService _currencyService;
    private readonly ICustomerActivityService _customerActivityService;
    private readonly ILocalizationService _localizationService;
    private readonly ILocalizedEntityService _localizedEntityService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly ISettingService _settingService;
    private readonly IStoreMappingService _storeMappingService;
    private readonly IStoreService _storeService;

    public CurrencyApiController(
        CurrencySettings currencySettings,
        ICurrencyModelFactory currencyModelFactory,
        ICurrencyService currencyService,
        ICustomerActivityService customerActivityService,
        ILocalizationService localizationService,
        ILocalizedEntityService localizedEntityService,
        INotificationService notificationService,
        IPermissionService permissionService,
        ISettingService settingService,
        IStoreMappingService storeMappingService,
        IStoreService storeService)
    {
        _currencySettings = currencySettings;
        _currencyModelFactory = currencyModelFactory;
        _currencyService = currencyService;
        _customerActivityService = customerActivityService;
        _localizationService = localizationService;
        _localizedEntityService = localizedEntityService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _settingService = settingService;
        _storeMappingService = storeMappingService;
        _storeService = storeService;
    }

    [HttpGet("List")]
    public async Task<IActionResult> List(bool liveRates = false)
    {
        var model = await _currencyModelFactory.PrepareCurrencySearchModelAsync(new CurrencySearchModel(), liveRates);
        return Ok(model);
    }

    [HttpPost("SaveSettings")]
    public async Task<IActionResult> SaveSettings([FromBody] CurrencySearchModel model)
    {
        _currencySettings.ActiveExchangeRateProviderSystemName = model.ExchangeRateProviderModel.ExchangeRateProvider;
        _currencySettings.AutoUpdateEnabled = model.ExchangeRateProviderModel.AutoUpdateEnabled;
        await _settingService.SaveSettingAsync(_currencySettings);

        return Ok("Settings saved successfully.");
    }

    [HttpPost("ApplyRates")]
    public async Task<IActionResult> ApplyRates([FromBody] IEnumerable<CurrencyExchangeRateModel> rateModels)
    {
        foreach (var rate in rateModels)
        {
            var currency = await _currencyService.GetCurrencyByCodeAsync(rate.CurrencyCode);
            if (currency != null)
            {
                currency.Rate = rate.Rate;
                currency.UpdatedOnUtc = DateTime.UtcNow;
                await _currencyService.UpdateCurrencyAsync(currency);
            }
        }

        return Ok("Exchange rates applied successfully.");
    }

    [HttpPost("SetPrimaryExchangeRateCurrency")]
    public async Task<IActionResult> MarkAsPrimaryExchangeRateCurrency(int id)
    {
        _currencySettings.PrimaryExchangeRateCurrencyId = id;
        await _settingService.SaveSettingAsync(_currencySettings);

        return Ok("Primary exchange rate currency set successfully.");
    }

    [HttpPost("SetPrimaryStoreCurrency")]
    public async Task<IActionResult> MarkAsPrimaryStoreCurrency(int id)
    {
        _currencySettings.PrimaryStoreCurrencyId = id;
        await _settingService.SaveSettingAsync(_currencySettings);

        return Ok("Primary store currency set successfully.");
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CurrencyModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var currency = model.ToEntity<Currency>();
        currency.CreatedOnUtc = DateTime.UtcNow;
        currency.UpdatedOnUtc = DateTime.UtcNow;
        await _currencyService.InsertCurrencyAsync(currency);

        await _customerActivityService.InsertActivityAsync("AddNewCurrency",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCurrency"), currency.Id), currency);

        await UpdateLocalesAsync(currency, model);
        await SaveStoreMappingsAsync(currency, model);

        return Ok(new { message = "Currency created successfully", currencyId = currency.Id });
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, [FromBody] CurrencyModel model)
    {
        var currency = await _currencyService.GetCurrencyByIdAsync(id);
        if (currency == null)
            return NotFound("Currency not found.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        currency = model.ToEntity(currency);
        currency.UpdatedOnUtc = DateTime.UtcNow;
        await _currencyService.UpdateCurrencyAsync(currency);

        await _customerActivityService.InsertActivityAsync("EditCurrency",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCurrency"), currency.Id), currency);

        await UpdateLocalesAsync(currency, model);
        await SaveStoreMappingsAsync(currency, model);

        return Ok(new { message = "Currency updated successfully", currencyId = currency.Id });
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var currency = await _currencyService.GetCurrencyByIdAsync(id);
        if (currency == null)
            return NotFound("Currency not found.");

        await _currencyService.DeleteCurrencyAsync(currency);

        await _customerActivityService.InsertActivityAsync("DeleteCurrency",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCurrency"), currency.Id), currency);

        return Ok("Currency deleted successfully.");
    }

    private async Task UpdateLocalesAsync(Currency currency, CurrencyModel model)
    {
        foreach (var localized in model.Locales)
        {
            await _localizedEntityService.SaveLocalizedValueAsync(currency, x => x.Name, localized.Name, localized.LanguageId);
        }
    }

    private async Task SaveStoreMappingsAsync(Currency currency, CurrencyModel model)
    {
        currency.LimitedToStores = model.SelectedStoreIds.Any();
        await _currencyService.UpdateCurrencyAsync(currency);

        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(currency);
        var allStores = await _storeService.GetAllStoresAsync();

        foreach (var store in allStores)
        {
            if (model.SelectedStoreIds.Contains(store.Id))
            {
                if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                    await _storeMappingService.InsertStoreMappingAsync(currency, store.Id);
            }
            else
            {
                var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                if (storeMappingToDelete != null)
                    await _storeMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
            }
        }
    }
}
