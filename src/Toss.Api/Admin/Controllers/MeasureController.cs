using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Directory;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Security;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Directory;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public partial class MeasureController : ControllerBase
{
    #region Fields

    private readonly ICustomerActivityService _customerActivityService;
    private readonly ILocalizationService _localizationService;
    private readonly IMeasureModelFactory _measureModelFactory;
    private readonly IMeasureService _measureService;
    private readonly IPermissionService _permissionService;
    private readonly ISettingService _settingService;
    private readonly MeasureSettings _measureSettings;

    #endregion

    #region Constructor

    public MeasureController(
        ICustomerActivityService customerActivityService,
        ILocalizationService localizationService,
        IMeasureModelFactory measureModelFactory,
        IMeasureService measureService,
        IPermissionService permissionService,
        ISettingService settingService,
        MeasureSettings measureSettings)
    {
        _customerActivityService = customerActivityService;
        _localizationService = localizationService;
        _measureModelFactory = measureModelFactory;
        _measureService = measureService;
        _permissionService = permissionService;
        _settingService = settingService;
        _measureSettings = measureSettings;
    }

    #endregion

    #region Methods

    [HttpGet("list")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> List()
    {
        var model = await _measureModelFactory.PrepareMeasureSearchModelAsync(new MeasureSearchModel());
        return Ok(model);
    }

    #region Weights

    [HttpPost("weights")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> Weights([FromBody] MeasureWeightSearchModel searchModel)
    {
        var model = await _measureModelFactory.PrepareMeasureWeightListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("weight/update")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> WeightUpdate([FromBody] MeasureWeightModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.SerializeErrors());

        var weight = await _measureService.GetMeasureWeightByIdAsync(model.Id);
        weight = model.ToEntity(weight);
        await _measureService.UpdateMeasureWeightAsync(weight);

        await _customerActivityService.InsertActivityAsync("EditMeasureWeight",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditMeasureWeight"), weight.Id), weight);

        return Ok();
    }

    [HttpPost("weight/add")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> WeightAdd([FromBody] MeasureWeightModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.SerializeErrors());

        var weight = model.ToEntity(new MeasureWeight());
        await _measureService.InsertMeasureWeightAsync(weight);

        await _customerActivityService.InsertActivityAsync("AddNewMeasureWeight",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewMeasureWeight"), weight.Id), weight);

        return Ok(new { Result = true });
    }

    [HttpDelete("weight/{id:int}")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> WeightDelete(int id)
    {
        var weight = await _measureService.GetMeasureWeightByIdAsync(id)
            ?? throw new ArgumentException("No weight found with the specified id", nameof(id));

        if (weight.Id == _measureSettings.BaseWeightId)
            return BadRequest(await _localizationService.GetResourceAsync("Admin.Configuration.Shipping.Measures.Weights.CantDeletePrimary"));

        await _measureService.DeleteMeasureWeightAsync(weight);
        await _customerActivityService.InsertActivityAsync("DeleteMeasureWeight",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteMeasureWeight"), weight.Id), weight);

        return Ok();
    }

    [HttpPost("weight/mark-primary/{id:int}")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> MarkAsPrimaryWeight(int id)
    {
        var weight = await _measureService.GetMeasureWeightByIdAsync(id)
            ?? throw new ArgumentException("No weight found with the specified id", nameof(id));

        _measureSettings.BaseWeightId = weight.Id;
        await _settingService.SaveSettingAsync(_measureSettings);

        return Ok(new { result = true });
    }

    #endregion

    #region Dimensions

    [HttpPost("dimensions")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> Dimensions([FromBody] MeasureDimensionSearchModel searchModel)
    {
        var model = await _measureModelFactory.PrepareMeasureDimensionListModelAsync(searchModel);
        return Ok(model);
    }

    [HttpPost("dimension/update")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> DimensionUpdate([FromBody] MeasureDimensionModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.SerializeErrors());

        var dimension = await _measureService.GetMeasureDimensionByIdAsync(model.Id);
        dimension = model.ToEntity(dimension);
        await _measureService.UpdateMeasureDimensionAsync(dimension);

        await _customerActivityService.InsertActivityAsync("EditMeasureDimension",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditMeasureDimension"), dimension.Id), dimension);

        return Ok();
    }

    [HttpPost("dimension/add")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> DimensionAdd([FromBody] MeasureDimensionModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.SerializeErrors());

        var dimension = model.ToEntity(new MeasureDimension());
        await _measureService.InsertMeasureDimensionAsync(dimension);

        await _customerActivityService.InsertActivityAsync("AddNewMeasureDimension",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewMeasureDimension"), dimension.Id), dimension);

        return Ok(new { Result = true });
    }

    [HttpDelete("dimension/{id:int}")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> DimensionDelete(int id)
    {
        var dimension = await _measureService.GetMeasureDimensionByIdAsync(id)
            ?? throw new ArgumentException("No dimension found with the specified id", nameof(id));

        if (dimension.Id == _measureSettings.BaseDimensionId)
            return BadRequest(await _localizationService.GetResourceAsync("Admin.Configuration.Shipping.Measures.Dimensions.CantDeletePrimary"));

        await _measureService.DeleteMeasureDimensionAsync(dimension);

        await _customerActivityService.InsertActivityAsync("DeleteMeasureDimension",
            string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteMeasureDimension"), dimension.Id), dimension);

        return Ok();
    }

    [HttpPost("dimension/mark-primary/{id:int}")]
    [CheckPermission(StandardPermission.Configuration.MANAGE_SHIPPING_SETTINGS)]
    public async Task<IActionResult> MarkAsPrimaryDimension(int id)
    {
        var dimension = await _measureService.GetMeasureDimensionByIdAsync(id)
            ?? throw new ArgumentException("No dimension found with the specified id", nameof(id));

        _measureSettings.BaseDimensionId = dimension.Id;
        await _settingService.SaveSettingAsync(_measureSettings);

        return Ok(new { result = true });
    }

    #endregion

    #endregion
}
