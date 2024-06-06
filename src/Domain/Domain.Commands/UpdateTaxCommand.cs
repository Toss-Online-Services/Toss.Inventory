namespace Domain.Commands;
public record UpdateTaxCommand : TaxCommand, ICommand<bool>;
