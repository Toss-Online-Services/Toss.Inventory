namespace Domain.Commands;

public record UpdateProductCommand : ProductCommand, ICommand<bool>;
