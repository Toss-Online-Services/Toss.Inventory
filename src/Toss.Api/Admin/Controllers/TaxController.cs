using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Tax;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Security;
using Nop.Services.Tax;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Tax;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/tax")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        #region Fields

        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly ITaxCategoryService _taxCategoryService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IWorkContext _workContext;
        private readonly ITaxModelFactory _taxModelFactory;
        private readonly ITaxPluginManager _taxPluginManager;
        private readonly TaxSettings _taxSettings;

        #endregion

        #region Ctor

        public TaxController(
            IPermissionService permissionService,
            ISettingService settingService,
            ITaxCategoryService taxCategoryService,
            IGenericAttributeService genericAttributeService,
            IWorkContext workContext,
            ITaxModelFactory taxModelFactory,
            ITaxPluginManager taxPluginManager,
            TaxSettings taxSettings)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _taxCategoryService = taxCategoryService;
            _genericAttributeService = genericAttributeService;
            _workContext = workContext;
            _taxModelFactory = taxModelFactory;
            _taxPluginManager = taxPluginManager;
            _taxSettings = taxSettings;
        }

        #endregion

        #region Methods

        #region Tax Providers

        [HttpGet("providers")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> Providers()
        {
            var model = await _taxModelFactory.PrepareTaxProviderSearchModelAsync(new TaxProviderSearchModel());
            return Ok(model);
        }

        [HttpPost("providers/list")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> Providers([FromBody] TaxProviderSearchModel searchModel)
        {
            var model = await _taxModelFactory.PrepareTaxProviderListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("providers/mark-primary")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> MarkAsPrimaryProvider([FromBody] string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return BadRequest("System name is required.");

            var taxProvider = await _taxPluginManager.LoadPluginBySystemNameAsync(systemName);
            if (taxProvider == null)
                return NotFound("Tax provider not found.");

            _taxSettings.ActiveTaxProviderSystemName = systemName;
            await _settingService.SaveSettingAsync(_taxSettings);

            return Ok();
        }

        #endregion

        #region Tax Categories

        [HttpGet("categories")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> Categories()
        {
            var model = await _taxModelFactory.PrepareTaxCategorySearchModelAsync(new TaxCategorySearchModel());
            return Ok(model);
        }

        [HttpPost("categories/list")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> Categories([FromBody] TaxCategorySearchModel searchModel)
        {
            var model = await _taxModelFactory.PrepareTaxCategoryListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("categories/update")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> CategoryUpdate([FromBody] TaxCategoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taxCategory = await _taxCategoryService.GetTaxCategoryByIdAsync(model.Id);
            taxCategory = model.ToEntity(taxCategory);
            await _taxCategoryService.UpdateTaxCategoryAsync(taxCategory);

            return NoContent();
        }

        [HttpPost("categories/add")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> CategoryAdd([FromBody] TaxCategoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taxCategory = new TaxCategory();
            taxCategory = model.ToEntity(taxCategory);
            await _taxCategoryService.InsertTaxCategoryAsync(taxCategory);

            return Ok(taxCategory);
        }

        [HttpDelete("categories/delete/{id}")]
        [CheckPermission(StandardPermission.Configuration.MANAGE_TAX_SETTINGS)]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var taxCategory = await _taxCategoryService.GetTaxCategoryByIdAsync(id);
            if (taxCategory == null)
                return NotFound("Tax category not found.");

            await _taxCategoryService.DeleteTaxCategoryAsync(taxCategory);
            return NoContent();
        }

        #endregion

        #endregion
    }
}
