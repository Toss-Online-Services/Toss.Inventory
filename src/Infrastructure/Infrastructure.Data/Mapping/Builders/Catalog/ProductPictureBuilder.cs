using Domain.Entities.Media;
using FluentMigrator.Builders.Create.Table;
using Infrastructure.Data.Extensions;

namespace Infrastructure.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product picture entity builder
/// </summary>
public partial class ProductPictureBuilder : NopEntityBuilder<ProductPicture>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ProductPicture.PictureId)).AsInt32().ForeignKey<Picture>()
            .WithColumn(nameof(ProductPicture.ProductId)).AsInt32().ForeignKey<Product>();
    }

    #endregion
}
