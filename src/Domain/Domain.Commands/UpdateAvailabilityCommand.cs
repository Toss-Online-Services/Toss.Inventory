namespace Domain.Commands;

public record UpdateAvailabilityCommand : AvailabilityCommand, ICommand<bool>;
