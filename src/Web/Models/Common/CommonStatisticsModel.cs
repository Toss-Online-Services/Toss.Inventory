namespace Web.Models.Common;

public partial record CommonStatisticsModel : BaseNopModel
{
    public int NumberOfOrders { get; set; }

    public int NumberOfCustomers { get; set; }

    public int NumberOfPendingReturnRequests { get; set; }

    public int NumberOfLowStockProducts { get; set; }
}