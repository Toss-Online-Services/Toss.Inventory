﻿namespace Domain.Models;
public record GiftCardCommand
{
    public bool IsGiftCard { get; init; }
    public int GiftCardTypeId { get; init; }
    public decimal? OverriddenGiftCardAmount { get; init; }

}

