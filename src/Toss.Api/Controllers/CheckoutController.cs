//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Nop.Core;
//using Nop.Core.Domain.Common;
//using Nop.Core.Domain.Customers;
//using Nop.Core.Domain.Orders;
//using Nop.Core.Domain.Payments;
//using Nop.Core.Domain.Shipping;
//using Nop.Core.Domain.Tax;
//using Nop.Services.Attributes;
//using Nop.Services.Catalog;
//using Nop.Services.Common;
//using Nop.Services.Customers;
//using Nop.Services.Directory;
//using Nop.Services.Localization;
//using Nop.Services.Orders;
//using Nop.Services.Payments;
//using Nop.Services.Shipping;
//using Nop.Services.Tax;
//using Nop.Web.Factories;
//using Nop.Web.Framework.Mvc.Filters;
//using Nop.Web.Models.Checkout;
//using Nop.Web.Models.Common;
//using Toss.Api.Factories;
//using Toss.Api.Models.Common;
//using ILogger = Nop.Services.Logging.ILogger;

//namespace Nop.Web.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [IgnoreAntiforgeryToken]
//    public class CheckoutController : ControllerBase
//    {
//        #region Fields

//        private readonly AddressSettings _addressSettings;
//        private readonly CustomerSettings _customerSettings;
//        private readonly IAddressModelFactory _addressModelFactory;
//        private readonly IAddressService _addressService;
//        private readonly IAttributeParser<AddressAttribute, AddressAttributeValue> _addressAttributeParser;
//        private readonly ICheckoutModelFactory _checkoutModelFactory;
//        private readonly ICountryService _countryService;
//        private readonly ICustomerService _customerService;
//        private readonly IGenericAttributeService _genericAttributeService;
//        private readonly ILocalizationService _localizationService;
//        private readonly ILogger _logger;
//        private readonly IOrderProcessingService _orderProcessingService;
//        private readonly IOrderService _orderService;
//        private readonly IPaymentPluginManager _paymentPluginManager;
//        private readonly IPaymentService _paymentService;
//        private readonly IProductService _productService;
//        private readonly IShippingService _shippingService;
//        private readonly IShoppingCartService _shoppingCartService;
//        private readonly ITaxService _taxService;
//        private readonly IWorkContext _workContext;
//        private readonly ShippingSettings _shippingSettings;

//        #endregion

//        #region Ctor

//        public CheckoutController(
//            AddressSettings addressSettings,
//            CustomerSettings customerSettings,
//            IAddressModelFactory addressModelFactory,
//            IAddressService addressService,
//            IAttributeParser<AddressAttribute, AddressAttributeValue> addressAttributeParser,
//            ICheckoutModelFactory checkoutModelFactory,
//            ICountryService countryService,
//            ICustomerService customerService,
//            IGenericAttributeService genericAttributeService,
//            ILocalizationService localizationService,
//            ILogger logger,
//            IOrderProcessingService orderProcessingService,
//            IOrderService orderService,
//            IPaymentPluginManager paymentPluginManager,
//            IPaymentService paymentService,
//            IProductService productService,
//            IShippingService shippingService,
//            IShoppingCartService shoppingCartService,
//            ITaxService taxService,
//            IWorkContext workContext,
//            ShippingSettings shippingSettings)
//        {
//            _addressSettings = addressSettings;
//            _customerSettings = customerSettings;
//            _addressModelFactory = addressModelFactory;
//            _addressService = addressService;
//            _addressAttributeParser = addressAttributeParser;
//            _checkoutModelFactory = checkoutModelFactory;
//            _countryService = countryService;
//            _customerService = customerService;
//            _genericAttributeService = genericAttributeService;
//            _localizationService = localizationService;
//            _logger = logger;
//            _orderProcessingService = orderProcessingService;
//            _orderService = orderService;
//            _paymentPluginManager = paymentPluginManager;
//            _paymentService = paymentService;
//            _productService = productService;
//            _shippingService = shippingService;
//            _shoppingCartService = shoppingCartService;
//            _taxService = taxService;
//            _workContext = workContext;
//            _shippingSettings = shippingSettings;
//        }

//        #endregion

//        #region Methods

//        [HttpGet("GetAddress/{addressId}")]
//        public async Task<IActionResult> GetAddressById(int addressId)
//        {
//            try
//            {
//                var customer = await _workContext.GetCurrentCustomerAsync();
//                var address = await _customerService.GetCustomerAddressAsync(customer.Id, addressId);
//                if (address == null)
//                    return NotFound();

//                var addressModel = new AddressModel();
//                await _addressModelFactory.PrepareAddressModelAsync(
//                    addressModel,
//                    address: address,
//                    excludeProperties: false,
//                    addressSettings: _addressSettings,
//                    prePopulateWithCustomerFields: true,
//                    customer: customer);

//                return Ok(addressModel);
//            }
//            catch (Exception ex)
//            {
//                await _logger.WarningAsync(ex.Message, ex);
//                return StatusCode(500, "Internal server error");
//            }
//        }

//        [HttpPost("EditAddress")]
//        public async Task<IActionResult> EditAddress(AddressModel addressModel, [FromForm] IFormCollection form)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    var errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
//                    return BadRequest(errors);
//                }

//                var customer = await _workContext.GetCurrentCustomerAsync();
//                var store = await _storeContext.GetCurrentStoreAsync();
//                var cart = await _shoppingCartService.GetShoppingCartAsync(customer, ShoppingCartType.ShoppingCart, store.Id);

//                if (!cart.Any())
//                    return BadRequest("Your cart is empty");

//                var address = await _customerService.GetCustomerAddressAsync(customer.Id, addressModel.Id);
//                if (address == null)
//                    return NotFound("Address not found");

//                var customAttributes = await _addressAttributeParser.ParseCustomAttributesAsync(form, "address_attribute");
//                var customAttributeWarnings = await _addressAttributeParser.GetAttributeWarningsAsync(customAttributes);
//                if (customAttributeWarnings.Any())
//                    return BadRequest(customAttributeWarnings);

//                address = addressModel.ToEntity(address);
//                address.CustomAttributes = customAttributes;

//                await _addressService.UpdateAddressAsync(address);
//                return Ok("Address updated successfully");
//            }
//            catch (Exception ex)
//            {
//                await _logger.WarningAsync(ex.Message, ex);
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpPost("DeleteAddress/{addressId}")]
//        public async Task<IActionResult> DeleteAddress(int addressId)
//        {
//            try
//            {
//                var customer = await _workContext.GetCurrentCustomerAsync();
//                var store = await _storeContext.GetCurrentStoreAsync();
//                var cart = await _shoppingCartService.GetShoppingCartAsync(customer, ShoppingCartType.ShoppingCart, store.Id);

//                if (!cart.Any())
//                    return BadRequest("Your cart is empty");

//                var address = await _customerService.GetCustomerAddressAsync(customer.Id, addressId);
//                if (address == null)
//                    return NotFound();

//                await _customerService.RemoveCustomerAddressAsync(customer, address);
//                await _customerService.UpdateCustomerAsync(customer);
//                await _addressService.DeleteAddressAsync(address);

//                return Ok("Address deleted successfully");
//            }
//            catch (Exception ex)
//            {
//                await _logger.WarningAsync(ex.Message, ex);
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpGet("Completed/{orderId?}")]
//        public async Task<IActionResult> Completed(int? orderId)
//        {
//            try
//            {
//                var customer = await _workContext.GetCurrentCustomerAsync();
//                if (await _customerService.IsGuestAsync(customer))
//                    return Unauthorized();

//                Order order = null;
//                if (orderId.HasValue)
//                {
//                    order = await _orderService.GetOrderByIdAsync(orderId.Value);
//                }

//                if (order == null)
//                {
//                    var store = await _storeContext.GetCurrentStoreAsync();
//                    order = (await _orderService.SearchOrdersAsync(storeId: store.Id, customerId: customer.Id, pageSize: 1))
//                        .FirstOrDefault();
//                }

//                if (order == null || order.Deleted || customer.Id != order.CustomerId)
//                    return NotFound();

//                var model = await _checkoutModelFactory.PrepareCheckoutCompletedModelAsync(order);
//                return Ok(model);
//            }
//            catch (Exception ex)
//            {
//                await _logger.WarningAsync(ex.Message, ex);
//                return StatusCode(500, ex.Message);
//            }
//        }

//        #endregion
//    }
//}
