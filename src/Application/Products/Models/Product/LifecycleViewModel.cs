namespace Application.Products.Models.Product;
public record LifecycleViewModel(DateTime? ManufactureDate, DateTime? ExpirationDate, string BatchNumber, string SerialNumber);
