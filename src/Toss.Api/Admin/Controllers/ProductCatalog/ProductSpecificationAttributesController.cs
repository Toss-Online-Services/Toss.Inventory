using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Controllers.ProductCatalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecificationAttributesController : ControllerBase
    {
        #region Fields

        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly IProductModelFactory _productModelFactory;

        #endregion

        #region Ctor

        public ProductSpecificationAttributesController(
            ISpecificationAttributeService specificationAttributeService,
            IProductService productService,
            IWorkContext workContext,
            INotificationService notificationService,
            IPermissionService permissionService,
            ILocalizedEntityService localizedEntityService,
            IProductModelFactory productModelFactory)
        {
            _specificationAttributeService = specificationAttributeService;
            _productService = productService;
            _workContext = workContext;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _localizedEntityService = localizedEntityService;
            _productModelFactory = productModelFactory;
        }

        #endregion

        #region Product specification attributes

        [HttpPost("add")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> ProductSpecificationAttributeAdd(AddSpecificationAttributeModel model, bool continueEditing)
        {
            var product = await _productService.GetProductByIdAsync(model.ProductId);
            if (product == null)
            {
                _notificationService.ErrorNotification("No product found with the specified ID");
                return NotFound("No product found with the specified ID");
            }

            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
            {
                return Forbid("Access denied.");
            }

            if (model.AttributeTypeId != (int)SpecificationAttributeType.Option)
                model.AllowFiltering = false;

            if (model.AttributeTypeId == (int)SpecificationAttributeType.Option)
                model.ValueRaw = null;

            if (model.AttributeTypeId == (int)SpecificationAttributeType.CustomText || model.AttributeTypeId == (int)SpecificationAttributeType.Hyperlink)
                model.ValueRaw = model.Value;

            var psa = model.ToEntity<ProductSpecificationAttribute>();
            psa.CustomValue = model.ValueRaw;
            await _specificationAttributeService.InsertProductSpecificationAttributeAsync(psa);

            switch (psa.AttributeType)
            {
                case SpecificationAttributeType.CustomText:
                case SpecificationAttributeType.CustomHtmlText:
                    foreach (var localized in model.Locales)
                    {
                        await _localizedEntityService.SaveLocalizedValueAsync(psa, x => x.CustomValue, localized.Value, localized.LanguageId);
                    }
                    break;
            }

            return Ok(new { id = model.ProductId });
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_VIEW)]
        public virtual async Task<IActionResult> ProductSpecAttrList(ProductSpecificationAttributeSearchModel searchModel)
        {
            var product = await _productService.GetProductByIdAsync(searchModel.ProductId);
            if (product == null)
            {
                return NotFound("No product found with the specified ID");
            }

            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && product.VendorId != currentVendor.Id)
            {
                return Forbid("Access denied.");
            }

            var model = await _productModelFactory.PrepareProductSpecificationAttributeListModelAsync(searchModel, product);
            return Ok(model);
        }

        [HttpPost("update")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> ProductSpecAttrUpdate(AddSpecificationAttributeModel model, bool continueEditing)
        {
            var psa = await _specificationAttributeService.GetProductSpecificationAttributeByIdAsync(model.SpecificationId);
            if (psa == null)
            {
                return NotFound("No product specification attribute found with the specified ID");
            }

            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && (await _productService.GetProductByIdAsync(psa.ProductId)).VendorId != currentVendor.Id)
            {
                return Forbid("Access denied.");
            }

            switch (model.AttributeTypeId)
            {
                case (int)SpecificationAttributeType.Option:
                    psa.AllowFiltering = model.AllowFiltering;
                    psa.SpecificationAttributeOptionId = model.SpecificationAttributeOptionId;
                    break;
                case (int)SpecificationAttributeType.CustomHtmlText:
                case (int)SpecificationAttributeType.CustomText:
                    psa.CustomValue = model.ValueRaw;
                    foreach (var localized in model.Locales)
                    {
                        await _localizedEntityService.SaveLocalizedValueAsync(psa, x => x.CustomValue, localized.ValueRaw, localized.LanguageId);
                    }
                    break;
            }

            psa.ShowOnProductPage = model.ShowOnProductPage;
            psa.DisplayOrder = model.DisplayOrder;
            await _specificationAttributeService.UpdateProductSpecificationAttributeAsync(psa);

            return Ok(new { id = psa.ProductId });
        }

        [HttpPost("delete")]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> ProductSpecAttrDelete(int specificationId)
        {
            var psa = await _specificationAttributeService.GetProductSpecificationAttributeByIdAsync(specificationId);
            if (psa == null)
            {
                return NotFound("No product specification attribute found with the specified ID");
            }

            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && (await _productService.GetProductByIdAsync(psa.ProductId)).VendorId != currentVendor.Id)
            {
                return Forbid("Access denied.");
            }

            await _specificationAttributeService.DeleteProductSpecificationAttributeAsync(psa);
            return Ok(new { id = psa.ProductId });
        }

        #endregion
    }
}
