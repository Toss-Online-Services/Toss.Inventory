using FluentMigrator.Builders.Create.Table;
using Infrastructure.Extensions;

namespace Infrastructure.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor note entity builder
/// </summary>
public partial class VendorNoteBuilder : NopEntityBuilder<VendorNote>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorNote.Note)).AsString(int.MaxValue).NotNullable()
            .WithColumn(nameof(VendorNote.VendorId)).AsInt32().ForeignKey<Vendor>();
    }

    #endregion
}