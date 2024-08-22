namespace Domain.Models;
public record TaxCommand()
{
    public bool IsTaxExempt { get; init; }
    public int TaxCategoryId { get; init; }

}
