using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using System.Threading.Tasks;
using System;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.Customers;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;

namespace Toss.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class CustomerRoleController : ControllerBase
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerRoleModelFactory _customerRoleModelFactory;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public CustomerRoleController(ICustomerActivityService customerActivityService,
            ICustomerRoleModelFactory customerRoleModelFactory,
            ICustomerService customerService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IProductService productService,
            IWorkContext workContext)
        {
            _customerActivityService = customerActivityService;
            _customerRoleModelFactory = customerRoleModelFactory;
            _customerService = customerService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _productService = productService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [HttpGet("list")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_VIEW)]
        public async Task<IActionResult> List()
        {
            var model = await _customerRoleModelFactory.PrepareCustomerRoleSearchModelAsync(new CustomerRoleSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_VIEW)]
        public async Task<IActionResult> List(CustomerRoleSearchModel searchModel)
        {
            var model = await _customerRoleModelFactory.PrepareCustomerRoleListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("create")]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> Create([FromBody] CustomerRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var customerRole = model.ToEntity<CustomerRole>();
                await _customerService.InsertCustomerRoleAsync(customerRole);

                await _customerActivityService.InsertActivityAsync("AddNewCustomerRole",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewCustomerRole"), customerRole.Name), customerRole);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Customers.CustomerRoles.Added"));
                return CreatedAtAction(nameof(Edit), new { id = customerRole.Id }, customerRole);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("edit/{id}")]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_VIEW)]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> Edit(int id)
        {
            var customerRole = await _customerService.GetCustomerRoleByIdAsync(id);
            if (customerRole == null)
                return NotFound();

            var model = await _customerRoleModelFactory.PrepareCustomerRoleModelAsync(null, customerRole);
            return Ok(model);
        }

        [HttpPut("edit/{id}")]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> Edit(int id, [FromBody] CustomerRoleModel model)
        {
            var customerRole = await _customerService.GetCustomerRoleByIdAsync(id);
            if (customerRole == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (customerRole.IsSystemRole && !model.Active)
                    throw new NopException(await _localizationService.GetResourceAsync("Admin.Customers.CustomerRoles.Fields.Active.CantEditSystem"));

                if (customerRole.IsSystemRole && !customerRole.SystemName.Equals(model.SystemName, StringComparison.InvariantCultureIgnoreCase))
                    throw new NopException(await _localizationService.GetResourceAsync("Admin.Customers.CustomerRoles.Fields.SystemName.CantEditSystem"));

                customerRole = model.ToEntity(customerRole);
                await _customerService.UpdateCustomerRoleAsync(customerRole);

                await _customerActivityService.InsertActivityAsync("EditCustomerRole",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditCustomerRole"), customerRole.Name), customerRole);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Customers.CustomerRoles.Updated"));
                return Ok(customerRole);
            }
            catch (Exception ex)
            {
                await _notificationService.ErrorNotificationAsync(ex);
                return StatusCode(500, "An error occurred while updating the customer role.");
            }
        }

        [HttpDelete("delete/{id}")]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> Delete(int id)
        {
            var customerRole = await _customerService.GetCustomerRoleByIdAsync(id);
            if (customerRole == null)
                return NotFound();

            try
            {
                await _customerService.DeleteCustomerRoleAsync(customerRole);

                await _customerActivityService.InsertActivityAsync("DeleteCustomerRole",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteCustomerRole"), customerRole.Name), customerRole);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Customers.CustomerRoles.Deleted"));
                return NoContent();
            }
            catch (Exception ex)
            {
                await _notificationService.ErrorNotificationAsync(ex);
                return StatusCode(500, "An error occurred while deleting the customer role.");
            }
        }

        [HttpGet("associate-product-popup")]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_VIEW)]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> AssociateProductToCustomerRolePopup()
        {
            var model = await _customerRoleModelFactory.PrepareCustomerRoleProductSearchModelAsync(new CustomerRoleProductSearchModel());
            return Ok(model);
        }

        [HttpPost("associate-product-popup-list")]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_VIEW)]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> AssociateProductToCustomerRolePopupList([FromBody] CustomerRoleProductSearchModel searchModel)
        {
            var model = await _customerRoleModelFactory.PrepareCustomerRoleProductListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("associate-product")]
        [CheckPermission(StandardPermission.Customers.CUSTOMER_ROLES_CREATE_EDIT_DELETE)]
        [CheckPermission(StandardPermission.Configuration.MANAGE_ACL)]
        public async Task<IActionResult> AssociateProductToCustomerRolePopup([FromBody] AddProductToCustomerRoleModel model)
        {
            var associatedProduct = await _productService.GetProductByIdAsync(model.AssociatedToProductId);
            if (associatedProduct == null)
                return NotFound("Cannot load a product");

            var currentVendor = await _workContext.GetCurrentVendorAsync();
            if (currentVendor != null && associatedProduct.VendorId != currentVendor.Id)
                return Unauthorized("This is not your product");

            return Ok(new { productId = associatedProduct.Id, productName = associatedProduct.Name });
        }

        #endregion
    }
}
