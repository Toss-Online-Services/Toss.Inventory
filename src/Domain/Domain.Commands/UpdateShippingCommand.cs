namespace Domain.Commands;

public record UpdateShippingCommand: ShippingCommand, ICommand<bool>;

