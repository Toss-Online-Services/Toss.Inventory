﻿using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;


namespace Infrastructure.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product attribute combination picture entity builder
/// </summary>
public partial class ProductAttributeCombinationPictureBuilder : NopEntityBuilder<ProductAttributeCombinationPicture>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ProductAttributeCombinationPicture.ProductAttributeCombinationId)).AsInt32().ForeignKey<ProductAttributeCombination>()
            .WithColumn(nameof(ProductAttributeCombinationPicture.PictureId)).AsInt32();
    }

    #endregion
}