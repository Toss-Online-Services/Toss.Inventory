using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;


namespace Infrastructure.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product attribute value entity builder
/// </summary>
public partial class ProductAttributeValueBuilder : NopEntityBuilder<ProductAttributeValue>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ProductAttributeValue.Name)).AsString(400).NotNullable()
            .WithColumn(nameof(ProductAttributeValue.ColorSquaresRgb)).AsString(100).Nullable()
            .WithColumn(nameof(ProductAttributeValue.ProductAttributeMappingId)).AsInt32().ForeignKey<ProductAttributeMapping>();
    }

    #endregion
}