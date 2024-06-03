using Domain.Infrastructure;

namespace Domain.Entities.Product;
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
}

