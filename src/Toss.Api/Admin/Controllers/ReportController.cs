using Microsoft.AspNetCore.Mvc;
using Nop.Services.Security;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Models.Reports;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        #region Fields

        private readonly IPermissionService _permissionService;
        private readonly IReportModelFactory _reportModelFactory;

        #endregion

        #region Ctor

        public ReportController(
            IPermissionService permissionService,
            IReportModelFactory reportModelFactory)
        {
            _permissionService = permissionService;
            _reportModelFactory = reportModelFactory;
        }

        #endregion

        #region Methods

        #region Sales summary

        [HttpGet("sales-summary")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.SALES_SUMMARY)]
        public async Task<IActionResult> SalesSummary([FromQuery] List<int> orderStatuses = null, [FromQuery] List<int> paymentStatuses = null)
        {
            var model = await _reportModelFactory.PrepareSalesSummarySearchModelAsync(new SalesSummarySearchModel
            {
                OrderStatusIds = orderStatuses,
                PaymentStatusIds = paymentStatuses
            });
            return Ok(model);
        }

        [HttpPost("sales-summary/list")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.SALES_SUMMARY)]
        public async Task<IActionResult> SalesSummaryList([FromBody] SalesSummarySearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareSalesSummaryListModelAsync(searchModel);
            return Ok(model);
        }

        #endregion

        #region Low stock

        [HttpGet("low-stock")]
        [CheckPermission(StandardPermission.Reports.LOW_STOCK)]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_VIEW)]
        public async Task<IActionResult> LowStock()
        {
            var model = await _reportModelFactory.PrepareLowStockProductSearchModelAsync(new LowStockProductSearchModel());
            return Ok(model);
        }

        [HttpPost("low-stock/list")]
        [CheckPermission(StandardPermission.Reports.LOW_STOCK)]
        [CheckPermission(StandardPermission.Catalog.PRODUCTS_VIEW)]
        public async Task<IActionResult> LowStockList([FromBody] LowStockProductSearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareLowStockProductListModelAsync(searchModel);
            return Ok(model);
        }

        #endregion

        #region Bestsellers

        [HttpGet("bestsellers")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.BESTSELLERS)]
        public async Task<IActionResult> Bestsellers()
        {
            var model = await _reportModelFactory.PrepareBestsellerSearchModelAsync(new BestsellerSearchModel());
            return Ok(model);
        }

        [HttpPost("bestsellers/list")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.BESTSELLERS)]
        public async Task<IActionResult> BestsellersList([FromBody] BestsellerSearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareBestsellerListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("bestsellers/aggregates")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.BESTSELLERS)]
        public async Task<IActionResult> BestsellersReportAggregates([FromBody] BestsellerSearchModel searchModel)
        {
            var totalAmount = await _reportModelFactory.GetBestsellerTotalAmountAsync(searchModel);
            return Ok(new { aggregatortotal = totalAmount });
        }

        #endregion

        #region Never Sold

        [HttpGet("never-sold")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.PRODUCTS_NEVER_PURCHASED)]
        public async Task<IActionResult> NeverSold()
        {
            var model = await _reportModelFactory.PrepareNeverSoldSearchModelAsync(new NeverSoldReportSearchModel());
            return Ok(model);
        }

        [HttpPost("never-sold/list")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.PRODUCTS_NEVER_PURCHASED)]
        public async Task<IActionResult> NeverSoldList([FromBody] NeverSoldReportSearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareNeverSoldListModelAsync(searchModel);
            return Ok(model);
        }

        #endregion

        #region Country sales

        [HttpGet("country-sales")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.COUNTRY_SALES)]
        public async Task<IActionResult> CountrySales()
        {
            var model = await _reportModelFactory.PrepareCountrySalesSearchModelAsync(new CountryReportSearchModel());
            return Ok(model);
        }

        [HttpPost("country-sales/list")]
        [CheckPermission(StandardPermission.Orders.ORDERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.COUNTRY_SALES)]
        public async Task<IActionResult> CountrySalesList([FromBody] CountryReportSearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareCountrySalesListModelAsync(searchModel);
            return Ok(model);
        }

        #endregion

        #region Customer reports

        [HttpGet("registered-customers")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.REGISTERED_CUSTOMERS)]
        public async Task<IActionResult> RegisteredCustomers()
        {
            var model = await _reportModelFactory.PrepareCustomerReportsSearchModelAsync(new CustomerReportsSearchModel());
            return Ok(model);
        }

        [HttpGet("best-customers/order-total")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_ORDER_TOTAL)]
        public async Task<IActionResult> BestCustomersByOrderTotal()
        {
            var model = await _reportModelFactory.PrepareCustomerReportsSearchModelAsync(new CustomerReportsSearchModel());
            return Ok(model);
        }

        [HttpGet("best-customers/number-of-orders")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_NUMBER_OF_ORDERS)]
        public async Task<IActionResult> BestCustomersByNumberOfOrders()
        {
            var model = await _reportModelFactory.PrepareCustomerReportsSearchModelAsync(new CustomerReportsSearchModel());
            return Ok(model);
        }

        [HttpPost("best-customers/order-total/list")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_ORDER_TOTAL)]
        public async Task<IActionResult> ReportBestCustomersByOrderTotalList([FromBody] BestCustomersReportSearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareBestCustomersReportListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("best-customers/number-of-orders/list")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.CUSTOMERS_BY_NUMBER_OF_ORDERS)]
        public async Task<IActionResult> ReportBestCustomersByNumberOfOrdersList([FromBody] BestCustomersReportSearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareBestCustomersReportListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost("registered-customers/list")]
        [CheckPermission(StandardPermission.Customers.CUSTOMERS_VIEW)]
        [CheckPermission(StandardPermission.Reports.REGISTERED_CUSTOMERS)]
        public async Task<IActionResult> ReportRegisteredCustomersList([FromBody] RegisteredCustomersReportSearchModel searchModel)
        {
            var model = await _reportModelFactory.PrepareRegisteredCustomersReportListModelAsync(searchModel);
            return Ok(model);
        }

        #endregion

        #endregion
    }
}
