using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;

namespace Infrastructure.Mapping.Builders.Customers;

/// <summary>
/// Represents a customer address mapping entity builder
/// </summary>
public partial class CustomerAddressMappingBuilder : NopEntityBuilder<CustomerAddressMapping>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(NameCompatibilityManager.GetColumnName(typeof(CustomerAddressMapping), nameof(CustomerAddressMapping.AddressId)))
            .AsInt32().ForeignKey<Address>().PrimaryKey()
            .WithColumn(NameCompatibilityManager.GetColumnName(typeof(CustomerAddressMapping), nameof(CustomerAddressMapping.CustomerId)))
            .AsInt32().ForeignKey<Customer>().PrimaryKey();
    }

    #endregion
}