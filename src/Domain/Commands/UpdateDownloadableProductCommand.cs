namespace Domain.Commands;
public record UpdateDownloadableProductCommand : DownloadableProductCommand, ICommand<bool>;
