namespace Domain.Entities.Orders;

/// <summary>
/// Order placed event
/// </summary>
public partial class OrderPlacedEvent
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="order">Order</param>
    public OrderPlacedEvent(Order order)
    {
        Order = order;
    }

    /// <summary>
    /// Order
    /// </summary>
    public Order Order { get; }
}