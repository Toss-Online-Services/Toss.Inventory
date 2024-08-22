﻿namespace Domain.Entities.Catalog;

/// <summary>
/// Represents a product tag
/// </summary>
public class ProductTag : Entity, ILocalizedEntity, ISlugSupported
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }
}