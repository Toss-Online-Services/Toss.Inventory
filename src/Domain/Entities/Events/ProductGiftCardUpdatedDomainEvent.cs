﻿namespace Domain.Entities.Events;
public record ProductGiftCardUpdatedDomainEvent(Guid ProductId, GiftCard GiftCard) : BaseEvent;