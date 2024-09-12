using FluentMigrator.Builders.Create.Table;

namespace Infrastructure.Mapping.Builders.Common;

/// <summary>
/// Represents a address attribute entity builder
/// </summary>
public partial class AddressAttributeBuilder : NopEntityBuilder<AddressAttribute>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(AddressAttribute.Name)).AsString(400).NotNullable();
    }

    #endregion
}