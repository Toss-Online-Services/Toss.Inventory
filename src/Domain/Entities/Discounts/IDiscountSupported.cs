﻿namespace Domain.Entities.Discounts;

/// <summary>
/// Represents an entity which supports discounts
/// </summary>
public partial interface IDiscountSupported<T> where T : DiscountMapping
{
    int Id { get; set; }
}