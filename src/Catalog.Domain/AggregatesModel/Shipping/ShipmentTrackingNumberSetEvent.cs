namespace Catalog.Domain.AggregatesModel.Shipping;

/// <summary>
/// Shipment tracking number set event
/// </summary>
public partial class ShipmentTrackingNumberSetEvent
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="shipment">Shipment</param>
    public ShipmentTrackingNumberSetEvent(Shipment shipment)
    {
        Shipment = shipment;
    }

    /// <summary>
    /// Shipment
    /// </summary>
    public Shipment Shipment { get; }
}