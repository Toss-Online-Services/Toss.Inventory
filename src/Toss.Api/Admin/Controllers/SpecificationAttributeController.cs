using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/specification-attribute")]
    [ApiController]
    public class SpecificationAttributeController : ControllerBase
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISpecificationAttributeModelFactory _specificationAttributeModelFactory;
        private readonly ISpecificationAttributeService _specificationAttributeService;

        #endregion

        #region Ctor

        public SpecificationAttributeController(
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISpecificationAttributeModelFactory specificationAttributeModelFactory,
            ISpecificationAttributeService specificationAttributeService)
        {
            _customerActivityService = customerActivityService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _specificationAttributeModelFactory = specificationAttributeModelFactory;
            _specificationAttributeService = specificationAttributeService;
        }

        #endregion

        #region Utilities

        private async Task UpdateAttributeLocalesAsync(SpecificationAttribute specificationAttribute, SpecificationAttributeModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(specificationAttribute, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        private async Task UpdateAttributeGroupLocalesAsync(SpecificationAttributeGroup specificationAttributeGroup, SpecificationAttributeGroupModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(specificationAttributeGroup, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        private async Task UpdateOptionLocalesAsync(SpecificationAttributeOption specificationAttributeOption, SpecificationAttributeOptionModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(specificationAttributeOption, x => x.Name, localized.Name, localized.LanguageId);
            }
        }

        #endregion

        #region Specification attributes

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_VIEW)]
        public async Task<IActionResult> List()
        {
            var model = await _specificationAttributeModelFactory.PrepareSpecificationAttributeGroupSearchModelAsync(new SpecificationAttributeGroupSearchModel());
            return Ok(model);
        }

        [HttpPost("group-list")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_VIEW)]
        public async Task<IActionResult> SpecificationAttributeGroupList([FromBody] SpecificationAttributeGroupSearchModel searchModel)
        {
            var model = await _specificationAttributeModelFactory.PrepareSpecificationAttributeGroupListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("attribute-list")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_VIEW)]
        public async Task<IActionResult> SpecificationAttributeList([FromBody] SpecificationAttributeSearchModel searchModel)
        {
            SpecificationAttributeGroup group = null;
            if (searchModel.SpecificationAttributeGroupId > 0)
            {
                group = await _specificationAttributeService.GetSpecificationAttributeGroupByIdAsync(searchModel.SpecificationAttributeGroupId)
                    ?? throw new ArgumentException("No specification attribute group found with the specified id");
            }

            var model = await _specificationAttributeModelFactory.PrepareSpecificationAttributeListModelAsync(searchModel, group);
            return Ok(model);
        }

        [HttpPost("create-group")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> CreateSpecificationAttributeGroup([FromBody] SpecificationAttributeGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var specificationAttributeGroup = model.ToEntity<SpecificationAttributeGroup>();
                await _specificationAttributeService.InsertSpecificationAttributeGroupAsync(specificationAttributeGroup);
                await UpdateAttributeGroupLocalesAsync(specificationAttributeGroup, model);

                await _customerActivityService.InsertActivityAsync("AddNewSpecAttributeGroup",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewSpecAttributeGroup"), specificationAttributeGroup.Name), specificationAttributeGroup);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Added"));

                return Ok(specificationAttributeGroup);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("create-attribute")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> CreateSpecificationAttribute([FromBody] SpecificationAttributeModel model)
        {
            if (ModelState.IsValid)
            {
                var specificationAttribute = model.ToEntity<SpecificationAttribute>();
                await _specificationAttributeService.InsertSpecificationAttributeAsync(specificationAttribute);
                await UpdateAttributeLocalesAsync(specificationAttribute, model);

                await _customerActivityService.InsertActivityAsync("AddNewSpecAttribute",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewSpecAttribute"), specificationAttribute.Name), specificationAttribute);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Added"));

                return Ok(specificationAttribute);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("edit-group/{id}")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> EditSpecificationAttributeGroup(int id, [FromBody] SpecificationAttributeGroupModel model)
        {
            var specificationAttributeGroup = await _specificationAttributeService.GetSpecificationAttributeGroupByIdAsync(id);
            if (specificationAttributeGroup == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                specificationAttributeGroup = model.ToEntity(specificationAttributeGroup);
                await _specificationAttributeService.UpdateSpecificationAttributeGroupAsync(specificationAttributeGroup);
                await UpdateAttributeGroupLocalesAsync(specificationAttributeGroup, model);

                await _customerActivityService.InsertActivityAsync("EditSpecAttributeGroup",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditSpecAttributeGroup"), specificationAttributeGroup.Name), specificationAttributeGroup);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Updated"));

                return Ok(specificationAttributeGroup);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("delete-group/{id}")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> DeleteSpecificationAttributeGroup(int id)
        {
            var specificationAttributeGroup = await _specificationAttributeService.GetSpecificationAttributeGroupByIdAsync(id);
            if (specificationAttributeGroup == null)
                return NotFound();

            await _specificationAttributeService.DeleteSpecificationAttributeGroupAsync(specificationAttributeGroup);

            await _customerActivityService.InsertActivityAsync("DeleteSpecAttributeGroup",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteSpecAttributeGroup"), specificationAttributeGroup.Name), specificationAttributeGroup);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Deleted"));

            return NoContent();
        }

        [HttpDelete("delete-attribute/{id}")]
        [CheckPermission(StandardPermission.Catalog.SPECIFICATION_ATTRIBUTES_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> DeleteSpecificationAttribute(int id)
        {
            var specificationAttribute = await _specificationAttributeService.GetSpecificationAttributeByIdAsync(id);
            if (specificationAttribute == null)
                return NotFound();

            await _specificationAttributeService.DeleteSpecificationAttributeAsync(specificationAttribute);

            await _customerActivityService.InsertActivityAsync("DeleteSpecAttribute",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteSpecAttribute"), specificationAttribute.Name), specificationAttribute);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Deleted"));

            return NoContent();
        }

        #endregion
    }
}
