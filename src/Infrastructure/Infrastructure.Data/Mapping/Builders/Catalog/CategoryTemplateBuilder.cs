using FluentMigrator.Builders.Create.Table;

namespace Infrastructure.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a category template entity builder
/// </summary>
public partial class CategoryTemplateBuilder : NopEntityBuilder<CategoryTemplate>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(CategoryTemplate.Name)).AsString(400).NotNullable()
            .WithColumn(nameof(CategoryTemplate.ViewPath)).AsString(400).NotNullable();
    }

    #endregion
}
