using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Tax : ValueObject
{
    public bool IsTaxExempt { get; set; }
    public int TaxCategoryId { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsTaxExempt;
        yield return TaxCategoryId;

    }
}

