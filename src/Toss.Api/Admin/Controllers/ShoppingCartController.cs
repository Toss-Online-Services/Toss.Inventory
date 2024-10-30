using Microsoft.AspNetCore.Mvc;
using Nop.Services.Customers;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.ShoppingCart;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/shopping-cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IPermissionService _permissionService;
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IShoppingCartService _shoppingCartService;

        #endregion

        #region Ctor

        public ShoppingCartController(
            ICustomerService customerService,
            IPermissionService permissionService,
            IShoppingCartService shoppingCartService,
            IShoppingCartModelFactory shoppingCartModelFactory)
        {
            _customerService = customerService;
            _permissionService = permissionService;
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartService = shoppingCartService;
        }

        #endregion

        #region Methods

        [HttpGet("current-carts")]
        [CheckPermission(StandardPermission.Orders.CURRENT_CARTS_MANAGE)]
        public async Task<IActionResult> GetCurrentCarts()
        {
            var model = await _shoppingCartModelFactory.PrepareShoppingCartSearchModelAsync(new ShoppingCartSearchModel());
            return Ok(model);
        }

        [HttpPost("current-carts")]
        [CheckPermission(StandardPermission.Orders.CURRENT_CARTS_MANAGE)]
        public async Task<IActionResult> GetCurrentCarts([FromBody] ShoppingCartSearchModel searchModel)
        {
            var model = await _shoppingCartModelFactory.PrepareShoppingCartListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("cart-details")]
        [CheckPermission(StandardPermission.Orders.CURRENT_CARTS_MANAGE)]
        public async Task<IActionResult> GetCartDetails([FromBody] ShoppingCartItemSearchModel searchModel)
        {
            var customer = await _customerService.GetCustomerByIdAsync(searchModel.CustomerId);
            if (customer == null)
                return NotFound("No customer found with the specified id.");

            var model = await _shoppingCartModelFactory.PrepareShoppingCartItemListModelAsync(searchModel, customer);
            return Ok(model);
        }

        [HttpDelete("delete-item/{id}")]
        [CheckPermission(StandardPermission.Orders.CURRENT_CARTS_MANAGE)]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _shoppingCartService.DeleteShoppingCartItemAsync(id);
            return NoContent();
        }

        #endregion
    }
}
