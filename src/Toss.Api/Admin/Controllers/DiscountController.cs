using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Services.Catalog;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Discounts;

namespace Toss.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class DiscountController : ControllerBase
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly ICategoryService _categoryService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IDiscountModelFactory _discountModelFactory;
        private readonly IDiscountPluginManager _discountPluginManager;
        private readonly IDiscountService _discountService;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public DiscountController(CatalogSettings catalogSettings,
            ICategoryService categoryService,
            ICustomerActivityService customerActivityService,
            IDiscountModelFactory discountModelFactory,
            IDiscountPluginManager discountPluginManager,
            IDiscountService discountService,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IProductService productService)
        {
            _catalogSettings = catalogSettings;
            _categoryService = categoryService;
            _customerActivityService = customerActivityService;
            _discountModelFactory = discountModelFactory;
            _discountPluginManager = discountPluginManager;
            _discountService = discountService;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _productService = productService;
        }

        #endregion

        #region Methods

        #region Discounts

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> List()
        {
            if (_catalogSettings.IgnoreDiscounts)
                _notificationService.WarningNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Discounts.IgnoreDiscounts.Warning"));

            var model = await _discountModelFactory.PrepareDiscountSearchModelAsync(new DiscountSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> List([FromBody] DiscountSearchModel searchModel)
        {
            var model = await _discountModelFactory.PrepareDiscountListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("create")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Create([FromBody] DiscountModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var discount = model.ToEntity<Discount>();
            await _discountService.InsertDiscountAsync(discount);

            await _customerActivityService.InsertActivityAsync("AddNewDiscount",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewDiscount"), discount.Name), discount);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Discounts.Added"));

            return CreatedAtAction(nameof(Edit), new { id = discount.Id }, discount);
        }

        [HttpGet("edit/{id}")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> Edit(int id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null)
                return NotFound();

            var model = await _discountModelFactory.PrepareDiscountModelAsync(null, discount);
            return Ok(model);
        }

        [HttpPut("edit/{id}")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Edit(int id, [FromBody] DiscountModel model)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var prevDiscountType = discount.DiscountType;
            discount = model.ToEntity(discount);
            await _discountService.UpdateDiscountAsync(discount);

            if (prevDiscountType != discount.DiscountType)
            {
                switch (prevDiscountType)
                {
                    case DiscountType.AssignedToSkus:
                        await _productService.ClearDiscountProductMappingAsync(discount);
                        break;
                    case DiscountType.AssignedToCategories:
                        await _categoryService.ClearDiscountCategoryMappingAsync(discount);
                        break;
                    case DiscountType.AssignedToManufacturers:
                        await _manufacturerService.ClearDiscountManufacturerMappingAsync(discount);
                        break;
                }
            }

            await _customerActivityService.InsertActivityAsync("EditDiscount",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditDiscount"), discount.Name), discount);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Discounts.Updated"));
            return Ok(discount);
        }

        [HttpDelete("delete/{id}")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null)
                return NotFound();

            await _discountService.DeleteDiscountAsync(discount);

            await _customerActivityService.InsertActivityAsync("DeleteDiscount",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteDiscount"), discount.Name), discount);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Discounts.Deleted"));
            return NoContent();
        }

        #endregion

        #region Discount Requirements

        [HttpGet("requirements/config-url")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> GetDiscountRequirementConfigurationUrl(string systemName, int discountId, int? discountRequirementId)
        {
            if (string.IsNullOrEmpty(systemName))
                return BadRequest("System name is required");

            var discountRequirementRule = await _discountPluginManager.LoadPluginBySystemNameAsync(systemName)
                ?? throw new ArgumentException("Discount requirement rule could not be loaded");

            var discount = await _discountService.GetDiscountByIdAsync(discountId)
                ?? throw new ArgumentException("Discount could not be loaded");

            var url = discountRequirementRule.GetConfigurationUrl(discount.Id, discountRequirementId);
            return Ok(new { url });
        }

        [HttpGet("requirements/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> GetDiscountRequirements(int discountId, int discountRequirementId,
            int? parentId, int? interactionTypeId, bool deleteRequirement)
        {
            var requirements = new List<DiscountRequirementRuleModel>();

            // Fetch the discount entity by its ID
            var discount = await _discountService.GetDiscountByIdAsync(discountId);
            if (discount == null)
                return NotFound("Discount not found");

            // Fetch the specific discount requirement by its ID
            var discountRequirement = await _discountService.GetDiscountRequirementByIdAsync(discountRequirementId);
            if (discountRequirement != null)
            {
                // Deletion scenario
                if (deleteRequirement)
                {
                    await _discountService.DeleteDiscountRequirementAsync(discountRequirement, true);

                    var discountRequirements = await _discountService.GetAllDiscountRequirementsAsync(discount.Id);

                    // Delete the default group if there are no remaining requirements
                    if (!discountRequirements.Any(requirement => requirement.ParentId.HasValue))
                    {
                        foreach (var dr in discountRequirements)
                            await _discountService.DeleteDiscountRequirementAsync(dr, true);
                    }
                }
                // Update scenario
                else
                {
                    // Determine the default group ID for the discount requirements
                    var defaultGroupId = (await _discountService.GetAllDiscountRequirementsAsync(discount.Id, true))
                        .FirstOrDefault(requirement => requirement.IsGroup)?.Id ?? 0;

                    if (defaultGroupId == 0)
                    {
                        // Add a default requirement group if not already existing
                        var defaultGroup = new DiscountRequirement
                        {
                            IsGroup = true,
                            DiscountId = discount.Id,
                            InteractionType = RequirementGroupInteractionType.And,
                            DiscountRequirementRuleSystemName = await _localizationService
                                .GetResourceAsync("Admin.Promotions.Discounts.Requirements.DefaultRequirementGroup")
                        };

                        await _discountService.InsertDiscountRequirementAsync(defaultGroup);
                        defaultGroupId = defaultGroup.Id;
                    }

                    // Set the parent ID if provided, otherwise default to the default group ID
                    discountRequirement.ParentId = parentId ?? defaultGroupId;

                    // Update the interaction type if provided
                    if (interactionTypeId.HasValue)
                        discountRequirement.InteractionTypeId = interactionTypeId.Value;

                    await _discountService.UpdateDiscountRequirementAsync(discountRequirement);
                }
            }

            // Retrieve current requirements and map them to the model
            var topLevelRequirements = (await _discountService.GetAllDiscountRequirementsAsync(discount.Id, true))
                .Where(requirement => requirement.IsGroup).ToList();

            var interactionType = topLevelRequirements.FirstOrDefault()?.InteractionType;
            if (interactionType.HasValue)
            {
                requirements = (await _discountModelFactory
                    .PrepareDiscountRequirementRuleModelsAsync(topLevelRequirements, discount, interactionType.Value)).ToList();
            }

            // Retrieve available requirement groups for selection
            var requirementGroups = (await _discountService.GetAllDiscountRequirementsAsync(discount.Id))
                .Where(requirement => requirement.IsGroup);

            var availableRequirementGroups = requirementGroups
                .Select(requirement => new SelectListItem
                {
                    Value = requirement.Id.ToString(),
                    Text = requirement.DiscountRequirementRuleSystemName
                })
                .ToList();

            return Ok(new { Requirements = requirements, AvailableGroups = availableRequirementGroups });
        }

        #endregion

        #region Applied to Products

        [HttpPost("products/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> ProductList([FromBody] DiscountProductSearchModel searchModel)
        {
            var discount = await _discountService.GetDiscountByIdAsync(searchModel.DiscountId)
                ?? throw new ArgumentException("No discount found with the specified id");

            var model = await _discountModelFactory.PrepareDiscountProductListModelAsync(searchModel, discount);
            return Ok(model);
        }

        [HttpDelete("products/delete")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ProductDelete(int discountId, int productId)
        {
            var discount = await _discountService.GetDiscountByIdAsync(discountId)
                ?? throw new ArgumentException("No discount found with the specified id", nameof(discountId));

            var product = await _productService.GetProductByIdAsync(productId)
                ?? throw new ArgumentException("No product found with the specified id", nameof(productId));

            if (await _productService.GetDiscountAppliedToProductAsync(product.Id, discount.Id) is DiscountProductMapping discountProductMapping)
                await _productService.DeleteDiscountProductMappingAsync(discountProductMapping);

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpGet("products/add-popup")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ProductAddPopup(int discountId)
        {
            var model = await _discountModelFactory.PrepareAddProductToDiscountSearchModelAsync(new AddProductToDiscountSearchModel());
            return Ok(model);
        }

        [HttpPost("products/add-popup/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ProductAddPopupList([FromBody] AddProductToDiscountSearchModel searchModel)
        {
            var model = await _discountModelFactory.PrepareAddProductToDiscountListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("products/add-popup")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ProductAddPopup([FromBody] AddProductToDiscountModel model)
        {
            var discount = await _discountService.GetDiscountByIdAsync(model.DiscountId)
                ?? throw new ArgumentException("No discount found with the specified id");

            var selectedProducts = await _productService.GetProductsByIdsAsync(model.SelectedProductIds.ToArray());
            foreach (var product in selectedProducts)
            {
                if (await _productService.GetDiscountAppliedToProductAsync(product.Id, discount.Id) == null)
                    await _productService.InsertDiscountProductMappingAsync(new DiscountProductMapping { EntityId = product.Id, DiscountId = discount.Id });

                await _productService.UpdateProductAsync(product);
            }

            return Ok();
        }

        #endregion

        #region Applied to Categories

        [HttpPost("categories/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> CategoryList([FromBody] DiscountCategorySearchModel searchModel)
        {
            var discount = await _discountService.GetDiscountByIdAsync(searchModel.DiscountId)
                ?? throw new ArgumentException("No discount found with the specified id");

            var model = await _discountModelFactory.PrepareDiscountCategoryListModelAsync(searchModel, discount);
            return Ok(model);
        }

        [HttpDelete("categories/delete")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> CategoryDelete(int discountId, int categoryId)
        {
            var discount = await _discountService.GetDiscountByIdAsync(discountId)
                ?? throw new ArgumentException("No discount found with the specified id", nameof(discountId));

            var category = await _categoryService.GetCategoryByIdAsync(categoryId)
                ?? throw new ArgumentException("No category found with the specified id", nameof(categoryId));

            if (await _categoryService.GetDiscountAppliedToCategoryAsync(category.Id, discount.Id) is DiscountCategoryMapping mapping)
                await _categoryService.DeleteDiscountCategoryMappingAsync(mapping);

            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpGet("categories/add-popup")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> CategoryAddPopup(int discountId)
        {
            var model = await _discountModelFactory.PrepareAddCategoryToDiscountSearchModelAsync(new AddCategoryToDiscountSearchModel());
            return Ok(model);
        }

        [HttpPost("categories/add-popup/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> CategoryAddPopupList([FromBody] AddCategoryToDiscountSearchModel searchModel)
        {
            var model = await _discountModelFactory.PrepareAddCategoryToDiscountListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("categories/add-popup")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> CategoryAddPopup([FromBody] AddCategoryToDiscountModel model)
        {
            var discount = await _discountService.GetDiscountByIdAsync(model.DiscountId)
                ?? throw new ArgumentException("No discount found with the specified id");

            foreach (var id in model.SelectedCategoryIds)
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null) continue;

                if (await _categoryService.GetDiscountAppliedToCategoryAsync(category.Id, discount.Id) == null)
                    await _categoryService.InsertDiscountCategoryMappingAsync(new DiscountCategoryMapping { DiscountId = discount.Id, EntityId = category.Id });

                await _categoryService.UpdateCategoryAsync(category);
            }

            return Ok();
        }

        #endregion

        #region Applied to Manufacturers

        [HttpPost("manufacturers/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> ManufacturerList([FromBody] DiscountManufacturerSearchModel searchModel)
        {
            var discount = await _discountService.GetDiscountByIdAsync(searchModel.DiscountId)
                ?? throw new ArgumentException("No discount found with the specified id");

            var model = await _discountModelFactory.PrepareDiscountManufacturerListModelAsync(searchModel, discount);
            return Ok(model);
        }

        [HttpDelete("manufacturers/delete")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ManufacturerDelete(int discountId, int manufacturerId)
        {
            var discount = await _discountService.GetDiscountByIdAsync(discountId)
                ?? throw new ArgumentException("No discount found with the specified id", nameof(discountId));

            var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(manufacturerId)
                ?? throw new ArgumentException("No manufacturer found with the specified id", nameof(manufacturerId));

            if (await _manufacturerService.GetDiscountAppliedToManufacturerAsync(manufacturer.Id, discount.Id) is DiscountManufacturerMapping discountManufacturerMapping)
                await _manufacturerService.DeleteDiscountManufacturerMappingAsync(discountManufacturerMapping);

            await _manufacturerService.UpdateManufacturerAsync(manufacturer);
            return NoContent();
        }

        [HttpGet("manufacturers/add-popup")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ManufacturerAddPopup(int discountId)
        {
            var model = await _discountModelFactory.PrepareAddManufacturerToDiscountSearchModelAsync(new AddManufacturerToDiscountSearchModel());
            return Ok(model);
        }

        [HttpPost("manufacturers/add-popup/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ManufacturerAddPopupList([FromBody] AddManufacturerToDiscountSearchModel searchModel)
        {
            var model = await _discountModelFactory.PrepareAddManufacturerToDiscountListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("manufacturers/add-popup")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> ManufacturerAddPopup([FromBody] AddManufacturerToDiscountModel model)
        {
            var discount = await _discountService.GetDiscountByIdAsync(model.DiscountId)
                ?? throw new ArgumentException("No discount found with the specified id");

            foreach (var id in model.SelectedManufacturerIds)
            {
                var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);
                if (manufacturer == null) continue;

                if (await _manufacturerService.GetDiscountAppliedToManufacturerAsync(manufacturer.Id, discount.Id) == null)
                    await _manufacturerService.InsertDiscountManufacturerMappingAsync(new DiscountManufacturerMapping { EntityId = manufacturer.Id, DiscountId = discount.Id });

                await _manufacturerService.UpdateManufacturerAsync(manufacturer);
            }

            return Ok();
        }

        #endregion

        #region Discount Usage History

        [HttpPost("usage-history/list")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_VIEW)]
        public async Task<IActionResult> UsageHistoryList([FromBody] DiscountUsageHistorySearchModel searchModel)
        {
            var discount = await _discountService.GetDiscountByIdAsync(searchModel.DiscountId)
                ?? throw new ArgumentException("No discount found with the specified id");

            var model = await _discountModelFactory.PrepareDiscountUsageHistoryListModelAsync(searchModel, discount);
            return Ok(model);
        }

        [HttpDelete("usage-history/delete")]
        [CheckPermission(StandardPermission.Promotions.DISCOUNTS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> UsageHistoryDelete(int discountId, int id)
        {
            _ = await _discountService.GetDiscountByIdAsync(discountId)
                ?? throw new ArgumentException("No discount found with the specified id", nameof(discountId));

            var discountUsageHistoryEntry = await _discountService.GetDiscountUsageHistoryByIdAsync(id)
                ?? throw new ArgumentException("No discount usage history entry found with the specified id", nameof(id));

            await _discountService.DeleteDiscountUsageHistoryAsync(discountUsageHistoryEntry);
            return NoContent();
        }

        #endregion

        #endregion
    }
}
