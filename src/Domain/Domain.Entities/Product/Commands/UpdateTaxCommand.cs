namespace Domain.Entities.Product.Commands;
public record UpdateTaxCommand() : ICommand<bool>
{
    public bool IsTaxExempt { get; init; }
    public int TaxCategoryId { get; init; }

}
