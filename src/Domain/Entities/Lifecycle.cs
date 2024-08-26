namespace Toss.Inventory.Domain.Entities;
public class Lifecycle : ValueObject
{
    public DateTime? ManufactureDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public string BatchNumber { get; private set; }
    public string SerialNumber { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ManufactureDate;
        yield return ExpirationDate;
        yield return BatchNumber;
        yield return SerialNumber;

    }

    internal void Apply(UpdateLifecycleCommand lifecycle)
    {
        ManufactureDate = lifecycle.ManufactureDate;
        ExpirationDate = lifecycle.ExpirationDate;
        BatchNumber = lifecycle.BatchNumber;
        SerialNumber = lifecycle.SerialNumber;
    }
}

