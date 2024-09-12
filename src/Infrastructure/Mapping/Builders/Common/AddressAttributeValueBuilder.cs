using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;

namespace Infrastructure.Mapping.Builders.Common;

/// <summary>
/// Represents an address attribute value entity builder
/// </summary>
public partial class AddressAttributeValueBuilder : NopEntityBuilder<AddressAttributeValue>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AddressAttributeValue.Name)).AsString(400).NotNullable()
            .WithColumn(NameCompatibilityManager.GetColumnName(typeof(AddressAttributeValue), nameof(AddressAttributeValue.AttributeId))).AsInt32().ForeignKey<AddressAttribute>();
    }

    #endregion
}