namespace Domain.Commands;
public record UpdateLifecycleCommand : LifecycleCommand, ICommand<bool>;
