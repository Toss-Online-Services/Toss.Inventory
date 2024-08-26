namespace Domain.Commands;

public record UpdatePriceCommand : PriceCommand, ICommand<bool>;
