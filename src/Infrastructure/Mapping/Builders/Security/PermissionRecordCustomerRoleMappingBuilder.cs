using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;

namespace Infrastructure.Mapping.Builders.Security;

/// <summary>
/// Represents a permission record customer role mapping entity builder
/// </summary>
public partial class PermissionRecordCustomerRoleMappingBuilder : NopEntityBuilder<PermissionRecordCustomerRoleMapping>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(PermissionRecordCustomerRoleMapping.PermissionRecordId))
            .AsInt32().PrimaryKey().ForeignKey<PermissionRecord>()
            .WithColumn(nameof(PermissionRecordCustomerRoleMapping.CustomerRoleId))
            .AsInt32().PrimaryKey().ForeignKey<CustomerRole>();
    }

    #endregion
}
