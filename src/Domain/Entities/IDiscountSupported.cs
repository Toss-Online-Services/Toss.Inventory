﻿namespace Domain.Entities;

/// <summary>
/// Represents an entity which supports discounts
/// </summary>
public interface IDiscountSupported<T> where T : DiscountMapping
{
    int Id { get; }
}