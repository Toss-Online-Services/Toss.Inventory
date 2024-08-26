namespace Domain.Commands;
public record UpdateRentalProductCommand : RentalProductCommand, ICommand<bool>;
