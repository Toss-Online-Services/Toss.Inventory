namespace Application.Products.Models.Product;
public record ShippingViewModel(bool IsShipEnabled, bool IsFreeShipping, bool ShipSeparately, decimal AdditionalShippingCharge);
