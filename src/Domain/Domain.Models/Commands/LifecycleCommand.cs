

namespace Domain.Models.Commands;
public record LifecycleCommand
{
    public DateTime? ManufactureDate { get; init; }
    public DateTime? ExpirationDate { get; init; }
    public string BatchNumber { get; init; }
    public string SerialNumber { get; init; }

}

