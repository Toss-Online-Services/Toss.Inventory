//using System.Text;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Nop.Core.Domain.Localization;
//using Nop.Core.Infrastructure;
//using Nop.Services.Localization;
//using Nop.Services.Logging;
//using Nop.Services.Messages;
//using Nop.Services.Security;
//using Nop.Services.Stores;
//using Nop.Web.Framework.Mvc.Filters;
//using Toss.Api.Admin.Factories;
//using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
//using Toss.Api.Admin.Models.Localization;

//namespace Nop.Web.Areas.Admin.Controllers;

//[ApiController]
//[Route("api/admin/[controller]")]
//public partial class LanguageController : ControllerBase
//{
//    #region Const

//    protected const string FLAGS_PATH = @"images\flags";

//    #endregion

//    #region Fields

//    private readonly ICustomerActivityService _customerActivityService;
//    private readonly ILanguageModelFactory _languageModelFactory;
//    private readonly ILanguageService _languageService;
//    private readonly ILocalizationService _localizationService;
//    private readonly INopFileProvider _fileProvider;
//    private readonly INotificationService _notificationService;
//    private readonly IPermissionService _permissionService;
//    private readonly IStoreMappingService _storeMappingService;
//    private readonly IStoreService _storeService;

//    #endregion

//    #region Ctor

//    public LanguageController(ICustomerActivityService customerActivityService,
//        ILanguageModelFactory languageModelFactory,
//        ILanguageService languageService,
//        ILocalizationService localizationService,
//        INopFileProvider fileProvider,
//        INotificationService notificationService,
//        IPermissionService permissionService,
//        IStoreMappingService storeMappingService,
//        IStoreService storeService)
//    {
//        _customerActivityService = customerActivityService;
//        _languageModelFactory = languageModelFactory;
//        _languageService = languageService;
//        _localizationService = localizationService;
//        _fileProvider = fileProvider;
//        _notificationService = notificationService;
//        _permissionService = permissionService;
//        _storeMappingService = storeMappingService;
//        _storeService = storeService;
//    }

//    #endregion

//    #region Utilities

//    private async Task SaveStoreMappingsAsync(Language language, LanguageModel model)
//    {
//        language.LimitedToStores = model.SelectedStoreIds.Any();
//        await _languageService.UpdateLanguageAsync(language);

//        var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(language);
//        var allStores = await _storeService.GetAllStoresAsync();
//        foreach (var store in allStores)
//        {
//            if (model.SelectedStoreIds.Contains(store.Id))
//            {
//                if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
//                    await _storeMappingService.InsertStoreMappingAsync(language, store.Id);
//            }
//            else
//            {
//                var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
//                if (storeMappingToDelete != null)
//                    await _storeMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
//            }
//        }
//    }

//    #endregion

//    #region Languages

//    [HttpGet("list")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> GetLanguages()
//    {
//        var model = await _languageModelFactory.PrepareLanguageSearchModelAsync(new LanguageSearchModel());
//        return Ok(model);
//    }

//    [HttpPost("list")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> GetLanguageList([FromBody] LanguageSearchModel searchModel)
//    {
//        var model = await _languageModelFactory.PrepareLanguageListModelAsync(searchModel);
//        return Ok(model);
//    }

//    [HttpPost("create")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> CreateLanguage([FromBody] LanguageModel model)
//    {
//        if (!ModelState.IsValid)
//            return BadRequest(ModelState);

//        var language = model.ToEntity<Language>();
//        await _languageService.InsertLanguageAsync(language);
//        await _customerActivityService.InsertActivityAsync("AddNewLanguage",
//            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewLanguage"), language.Id), language);
//        await SaveStoreMappingsAsync(language, model);

//        return Ok(new { success = true, message = "Language created successfully", language.Id });
//    }

//    [HttpGet("edit/{id}")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> GetLanguageById(int id)
//    {
//        var language = await _languageService.GetLanguageByIdAsync(id);
//        if (language == null)
//            return NotFound();

//        var model = await _languageModelFactory.PrepareLanguageModelAsync(null, language);
//        return Ok(model);
//    }

//    [HttpPut("edit/{id}")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> EditLanguage(int id, [FromBody] LanguageModel model)
//    {
//        var language = await _languageService.GetLanguageByIdAsync(id);
//        if (language == null)
//            return NotFound();

//        if (!ModelState.IsValid)
//            return BadRequest(ModelState);

//        language = model.ToEntity(language);
//        await _languageService.UpdateLanguageAsync(language);
//        await SaveStoreMappingsAsync(language, model);
//        return Ok(new { success = true, message = "Language updated successfully" });
//    }

//    [HttpDelete("{id}")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> DeleteLanguage(int id)
//    {
//        var language = await _languageService.GetLanguageByIdAsync(id);
//        if (language == null)
//            return NotFound();

//        await _languageService.DeleteLanguageAsync(language);
//        return Ok(new { success = true, message = "Language deleted successfully" });
//    }

//    [HttpGet("flags")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public IActionResult GetAvailableFlagFileNames()
//    {
//        var flagNames = _fileProvider
//            .EnumerateFiles(_fileProvider.GetAbsolutePath(FLAGS_PATH), "*.png")
//            .Select(_fileProvider.GetFileName)
//            .Select(flagName => new SelectListItem { Text = flagName, Value = flagName })
//            .ToList();

//        return Ok(flagNames);
//    }

//    [HttpGet("culture-warning")]
//    public async Task<IActionResult> LanguageCultureWarning(string currentCulture, string changedCulture)
//    {
//        if (currentCulture != changedCulture)
//        {
//            return Ok(new
//            {
//                Result = string.Format(await _localizationService.GetResourceAsync("Admin.Configuration.Languages.CLDR.Warning"),
//                    Url.Action("GeneralCommon", "Setting"))
//            });
//        }

//        return Ok(new { Result = string.Empty });
//    }

//    #endregion

//    #region Resources

//    [HttpPost("resources")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> GetResources([FromBody] LocaleResourceSearchModel searchModel)
//    {
//        var language = await _languageService.GetLanguageByIdAsync(searchModel.LanguageId);
//        if (language == null)
//            return NotFound();

//        var model = await _languageModelFactory.PrepareLocaleResourceListModelAsync(searchModel, language);
//        return Ok(model);
//    }

//    [HttpPost("resource-update")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> UpdateResource([FromBody] LocaleResourceModel model)
//    {
//        if (!ModelState.IsValid)
//            return BadRequest(ModelState);

//        var resource = await _localizationService.GetLocaleStringResourceByIdAsync(model.Id);
//        if (!resource.ResourceName.Equals(model.ResourceName, StringComparison.InvariantCultureIgnoreCase))
//        {
//            var res = await _localizationService.GetLocaleStringResourceByNameAsync(model.ResourceName, model.LanguageId, false);
//            if (res != null && res.Id != resource.Id)
//                return Conflict("Resource name already exists");
//        }

//        resource = model.ToEntity(resource);
//        await _localizationService.UpdateLocaleStringResourceAsync(resource);
//        return Ok();
//    }

//    [HttpPost("resource-add/{languageId}")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> AddResource(int languageId, [FromBody] LocaleResourceModel model)
//    {
//        if (!ModelState.IsValid)
//            return BadRequest(ModelState);

//        var res = await _localizationService.GetLocaleStringResourceByNameAsync(model.ResourceName, model.LanguageId, false);
//        if (res != null)
//            return Conflict("Resource name already exists");

//        var resource = model.ToEntity<LocaleStringResource>();
//        resource.LanguageId = languageId;
//        await _localizationService.InsertLocaleStringResourceAsync(resource);
//        return Ok();
//    }

//    [HttpDelete("resource-delete/{id}")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> DeleteResource(int id)
//    {
//        var resource = await _localizationService.GetLocaleStringResourceByIdAsync(id);
//        if (resource == null)
//            return NotFound();

//        await _localizationService.DeleteLocaleStringResourceAsync(resource);
//        return Ok();
//    }

//    #endregion

//    #region Export / Import

//    [HttpGet("export-xml/{id}")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> ExportXml(int id)
//    {
//        var language = await _languageService.GetLanguageByIdAsync(id);
//        if (language == null)
//            return NotFound();

//        try
//        {
//            var xml = await _localizationService.ExportResourcesToXmlAsync(language);
//            return File(Encoding.UTF8.GetBytes(xml), "application/xml", "language_pack.xml");
//        }
//        catch (Exception exc)
//        {
//            await _notificationService.ErrorNotificationAsync(exc);
//            return BadRequest("Error exporting XML");
//        }
//    }

//    [HttpPost("import-xml/{id}")]
//    [CheckPermission(StandardPermission.Configuration.MANAGE_LANGUAGES)]
//    public async Task<IActionResult> ImportXml(int id, IFormFile importXmlFile)
//    {
//        var language = await _languageService.GetLanguageByIdAsync(id);
//        if (language == null)
//            return NotFound();

//        if (importXmlFile == null || importXmlFile.Length == 0)
//            return BadRequest("No file uploaded");

//        try
//        {
//            using var sr = new StreamReader(importXmlFile.OpenReadStream(), Encoding.UTF8);
//            await _localizationService.ImportResourcesFromXmlAsync(language, sr);
//            return Ok("Import successful");
//        }
//        catch (Exception exc)
//        {
//            await _notificationService.ErrorNotificationAsync(exc);
//            return BadRequest("Error importing XML");
//        }
//    }

//    #endregion
//}
