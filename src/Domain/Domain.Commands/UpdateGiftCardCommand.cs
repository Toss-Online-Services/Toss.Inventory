namespace Domain.Commands;
public record UpdateGiftCardCommand : GiftCardCommand, ICommand<bool>;
