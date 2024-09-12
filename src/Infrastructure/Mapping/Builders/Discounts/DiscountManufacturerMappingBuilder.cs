using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;

namespace Infrastructure.Mapping.Builders.Discounts;

/// <summary>
/// Represents a discount manufacturer mapping entity builder
/// </summary>
public partial class DiscountManufacturerMappingBuilder : NopEntityBuilder<DiscountManufacturerMapping>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(NameCompatibilityManager.GetColumnName(typeof(DiscountManufacturerMapping), nameof(DiscountManufacturerMapping.DiscountId)))
            .AsInt32().PrimaryKey().ForeignKey<Discount>()
            .WithColumn(NameCompatibilityManager.GetColumnName(typeof(DiscountManufacturerMapping), nameof(DiscountManufacturerMapping.EntityId)))
            .AsInt32().PrimaryKey().ForeignKey<Manufacturer>();
    }

    #endregion
}