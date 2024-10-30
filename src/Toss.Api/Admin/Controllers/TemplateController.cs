using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Topics;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Topics;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Templates;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/templates")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        #region Fields

        private readonly ICategoryTemplateService _categoryTemplateService;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerTemplateService _manufacturerTemplateService;
        private readonly IPermissionService _permissionService;
        private readonly IProductTemplateService _productTemplateService;
        private readonly ITemplateModelFactory _templateModelFactory;
        private readonly ITopicTemplateService _topicTemplateService;

        #endregion

        #region Ctor

        public TemplateController(
            ICategoryTemplateService categoryTemplateService,
            ILocalizationService localizationService,
            IManufacturerTemplateService manufacturerTemplateService,
            IPermissionService permissionService,
            IProductTemplateService productTemplateService,
            ITemplateModelFactory templateModelFactory,
            ITopicTemplateService topicTemplateService)
        {
            _categoryTemplateService = categoryTemplateService;
            _localizationService = localizationService;
            _manufacturerTemplateService = manufacturerTemplateService;
            _permissionService = permissionService;
            _productTemplateService = productTemplateService;
            _templateModelFactory = templateModelFactory;
            _topicTemplateService = topicTemplateService;
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> List()
        {
            var model = await _templateModelFactory.PrepareTemplatesModelAsync(new TemplatesModel());
            return Ok(model);
        }

        #region Category templates        

        [HttpPost("category/list")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> CategoryTemplates([FromBody] CategoryTemplateSearchModel searchModel)
        {
            var model = await _templateModelFactory.PrepareCategoryTemplateListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("category/update")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> CategoryTemplateUpdate([FromBody] CategoryTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = await _categoryTemplateService.GetCategoryTemplateByIdAsync(model.Id);
            if (template == null)
                return NotFound("Template not found.");

            template = model.ToEntity(template);
            await _categoryTemplateService.UpdateCategoryTemplateAsync(template);

            return NoContent();
        }

        [HttpPost("category/add")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> CategoryTemplateAdd([FromBody] CategoryTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = model.ToEntity(new CategoryTemplate());
            await _categoryTemplateService.InsertCategoryTemplateAsync(template);

            return Ok(new { Result = true });
        }

        [HttpDelete("category/delete/{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> CategoryTemplateDelete(int id)
        {
            var templates = await _categoryTemplateService.GetAllCategoryTemplatesAsync();
            if (templates.Count == 1)
                return BadRequest("Cannot delete the only template available.");

            var template = await _categoryTemplateService.GetCategoryTemplateByIdAsync(id);
            if (template == null)
                return NotFound("Template not found.");

            await _categoryTemplateService.DeleteCategoryTemplateAsync(template);

            return NoContent();
        }

        #endregion

        #region Manufacturer templates        

        [HttpPost("manufacturer/list")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ManufacturerTemplates([FromBody] ManufacturerTemplateSearchModel searchModel)
        {
            var model = await _templateModelFactory.PrepareManufacturerTemplateListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("manufacturer/update")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ManufacturerTemplateUpdate([FromBody] ManufacturerTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = await _manufacturerTemplateService.GetManufacturerTemplateByIdAsync(model.Id);
            if (template == null)
                return NotFound("Template not found.");

            template = model.ToEntity(template);
            await _manufacturerTemplateService.UpdateManufacturerTemplateAsync(template);

            return NoContent();
        }

        [HttpPost("manufacturer/add")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ManufacturerTemplateAdd([FromBody] ManufacturerTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = model.ToEntity(new ManufacturerTemplate());
            await _manufacturerTemplateService.InsertManufacturerTemplateAsync(template);

            return Ok(new { Result = true });
        }

        [HttpDelete("manufacturer/delete/{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ManufacturerTemplateDelete(int id)
        {
            var templates = await _manufacturerTemplateService.GetAllManufacturerTemplatesAsync();
            if (templates.Count == 1)
                return BadRequest("Cannot delete the only template available.");

            var template = await _manufacturerTemplateService.GetManufacturerTemplateByIdAsync(id);
            if (template == null)
                return NotFound("Template not found.");

            await _manufacturerTemplateService.DeleteManufacturerTemplateAsync(template);

            return NoContent();
        }

        #endregion

        #region Product templates

        [HttpPost("product/list")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ProductTemplates([FromBody] ProductTemplateSearchModel searchModel)
        {
            var model = await _templateModelFactory.PrepareProductTemplateListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("product/update")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ProductTemplateUpdate([FromBody] ProductTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = await _productTemplateService.GetProductTemplateByIdAsync(model.Id);
            if (template == null)
                return NotFound("Template not found.");

            template = model.ToEntity(template);
            await _productTemplateService.UpdateProductTemplateAsync(template);

            return NoContent();
        }

        [HttpPost("product/add")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ProductTemplateAdd([FromBody] ProductTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = model.ToEntity(new ProductTemplate());
            await _productTemplateService.InsertProductTemplateAsync(template);

            return Ok(new { Result = true });
        }

        [HttpDelete("product/delete/{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> ProductTemplateDelete(int id)
        {
            var templates = await _productTemplateService.GetAllProductTemplatesAsync();
            if (templates.Count == 1)
                return BadRequest("Cannot delete the only template available.");

            var template = await _productTemplateService.GetProductTemplateByIdAsync(id);
            if (template == null)
                return NotFound("Template not found.");

            await _productTemplateService.DeleteProductTemplateAsync(template);

            return NoContent();
        }

        #endregion

        #region Topic templates

        [HttpPost("topic/list")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> TopicTemplates([FromBody] TopicTemplateSearchModel searchModel)
        {
            var model = await _templateModelFactory.PrepareTopicTemplateListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPut("topic/update")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> TopicTemplateUpdate([FromBody] TopicTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = await _topicTemplateService.GetTopicTemplateByIdAsync(model.Id);
            if (template == null)
                return NotFound("Template not found.");

            template = model.ToEntity(template);
            await _topicTemplateService.UpdateTopicTemplateAsync(template);

            return NoContent();
        }

        [HttpPost("topic/add")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> TopicTemplateAdd([FromBody] TopicTemplateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var template = model.ToEntity(new TopicTemplate());
            await _topicTemplateService.InsertTopicTemplateAsync(template);

            return Ok(new { Result = true });
        }

        [HttpDelete("topic/delete/{id}")]
        [CheckPermission(StandardPermission.System.MANAGE_MAINTENANCE)]
        public async Task<IActionResult> TopicTemplateDelete(int id)
        {
            var templates = await _topicTemplateService.GetAllTopicTemplatesAsync();
            if (templates.Count == 1)
                return BadRequest("Cannot delete the only template available.");

            var template = await _topicTemplateService.GetTopicTemplateByIdAsync(id);
            if (template == null)
                return NotFound("Template not found.");

            await _topicTemplateService.DeleteTopicTemplateAsync(template);

            return NoContent();
        }

        #endregion

        #endregion
    }
}
