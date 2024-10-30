using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Catalog;
using Nop.Services.Security;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/search-complete")]
    [ApiController]
    public class SearchCompleteController : ControllerBase
    {
        #region Fields

        private readonly IPermissionService _permissionService;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public SearchCompleteController(
            IPermissionService permissionService,
            IProductService productService,
            IWorkContext workContext)
        {
            _permissionService = permissionService;
            _productService = productService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [HttpGet("autocomplete")]
        public async Task<IActionResult> SearchAutoComplete(string term)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.Security.ACCESS_ADMIN_PANEL))
                return Unauthorized("You do not have permission to access this resource.");

            const int searchTermMinimumLength = 3;
            if (string.IsNullOrWhiteSpace(term) || term.Length < searchTermMinimumLength)
                return BadRequest("Search term must be at least 3 characters long.");

            // Restrict to vendor's products if applicable
            var currentVendor = await _workContext.GetCurrentVendorAsync();
            var vendorId = currentVendor?.Id ?? 0;

            // Fetch products
            const int productNumber = 15;
            var products = await _productService.SearchProductsAsync(
                0,
                vendorId: vendorId,
                keywords: term,
                pageSize: productNumber,
                showHidden: true);

            var result = products.Select(p => new
            {
                label = p.Name,
                productid = p.Id
            }).ToList();

            return Ok(result);
        }

        #endregion
    }
}
