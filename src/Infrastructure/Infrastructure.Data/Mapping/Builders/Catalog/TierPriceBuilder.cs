using FluentMigrator.Builders.Create.Table;
using Infrastructure.Data.Extensions;

namespace Infrastructure.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a tier price entity builder
/// </summary>
public partial class TierPriceBuilder : NopEntityBuilder<TierPrice>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(TierPrice.CustomerRoleId)).AsInt32().Nullable()
            .WithColumn(nameof(TierPrice.ProductId)).AsInt32().ForeignKey<Product>();
    }

    #endregion
}
