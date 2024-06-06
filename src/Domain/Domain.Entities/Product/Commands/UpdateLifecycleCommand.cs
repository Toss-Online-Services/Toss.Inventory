namespace Domain.Entities.Product;
public record UpdateLifecycleCommand : ICommand<bool>
{
    public DateTime? ManufactureDate { get; init; }
    public DateTime? ExpirationDate { get; init; }
    public string BatchNumber { get; init; }
    public string SerialNumber { get; init; }
    
}

