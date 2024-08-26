using FluentMigrator.Builders.Create.Table;
using Infrastructure.Data.Extensions;

namespace Infrastructure.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a back in stock subscription entity builder
/// </summary>
public partial class BackInStockSubscriptionBuilder : NopEntityBuilder<BackInStockSubscription>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(BackInStockSubscription.CustomerId)).AsInt32()
            .WithColumn(nameof(BackInStockSubscription.ProductId)).AsInt32().ForeignKey<Product>();
    }

    #endregion
}
