using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;


namespace Infrastructure.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product product tag mapping entity builder
/// </summary>
public partial class ProductProductTagMappingBuilder : NopEntityBuilder<ProductProductTagMapping>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ProductProductTagMapping.ProductId))
            .AsInt32().PrimaryKey().ForeignKey<Product>()
            .WithColumn(nameof(ProductProductTagMapping.ProductTagId))
            .AsInt32().PrimaryKey().ForeignKey<ProductTag>();
    }

    #endregion
}
