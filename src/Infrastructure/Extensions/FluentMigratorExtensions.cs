using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using FluentMigrator.Builders.Alter.Table;
using FluentMigrator.Builders.Create;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Infrastructure.Extensions;
using FluentMigrator.Model;
using Domain;
using Domain.Infrastructure;
using LinqToDB.Mapping;

namespace Infrastructure.Extensions
{
    /// <summary>
    /// FluentMigrator extensions
    /// </summary>
    public static class FluentMigratorExtensions
    {
        #region Utils

        private const int DATE_TIME_PRECISION = 6;

        // Detect the current database provider (you need to configure this)
        private static readonly bool IsPostgres = true; // Set this based on your provider

        // Mapping from .NET types to FluentMigrator column types
        private static Dictionary<Type, Action<ICreateTableColumnAsTypeSyntax>> TypeMapping { get; } = new Dictionary<Type, Action<ICreateTableColumnAsTypeSyntax>>
        {
            [typeof(int)] = c => c.AsInt32(),
            [typeof(long)] = c => c.AsInt64(),
            [typeof(string)] = c => c.AsString(int.MaxValue).Nullable(),
            [typeof(bool)] = c => c.AsBoolean(),
            [typeof(decimal)] = c => c.AsDecimal(18, 4),
            [typeof(byte[])] = c => c.AsBinary(int.MaxValue),
            [typeof(Guid)] = c => c.AsGuid(),
            [typeof(DateTime)] = c =>
            {
                if (IsPostgres)
                {
                    c.AsCustom("timestamp"); // For PostgreSQL
                }
                else
                {
                    c.AsCustom($"datetime2({DATE_TIME_PRECISION})"); // For SQL Server
                }
            },
            [typeof(Enum)] = c => c.AsInt32() // Map enums as integers
        };

        // Method to define a column based on its property type
        private static void DefineByOwnType(string columnName, Type propType, CreateTableExpressionBuilder create, bool canBeNullable = false)
        {
            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("The column name cannot be empty");

            // Check if the property is a string or a collection (which could be nullable)
            if (propType == typeof(string) || propType.GetInterfaces().Any(i => i == typeof(System.Collections.IEnumerable) && i != typeof(string)))
                canBeNullable = true;

            var column = create.WithColumn(columnName);

            if (TypeMapping.ContainsKey(propType))
            {
                TypeMapping[propType](column);
            }
            else if (propType.IsEnum) // Handle enums directly
            {
                column.AsInt32(); // Map enum as int
            }
            else
            {
                throw new InvalidOperationException($"Unsupported property type: {propType.Name} for column {columnName}");
            }

            if (canBeNullable)
                create.Nullable();
        }

        #endregion

        /// <summary>
        /// Specifies a foreign key
        /// </summary>
        /// <typeparam name="TPrimary">The primary entity type</typeparam>
        /// <param name="column">The foreign key column</param>
        /// <param name="primaryTableName">The primary table name</param>
        /// <param name="primaryColumnName">The primary table's column name</param>
        /// <param name="onDelete">Behavior for DELETEs</param>
        /// <returns>Set column options or create a new column or set a foreign key cascade rule</returns>
        public static ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax ForeignKey<TPrimary>(this ICreateTableColumnOptionOrWithColumnSyntax column, string primaryTableName = null, string primaryColumnName = null, Rule onDelete = Rule.Cascade) where TPrimary : BaseEntity
        {
            primaryTableName ??= typeof(TPrimary).Name;
            primaryColumnName ??= nameof(BaseEntity.Id);

            return column.Indexed().ForeignKey(primaryTableName, primaryColumnName).OnDelete(onDelete);
        }

        /// <summary>
        /// Specifies a foreign key
        /// </summary>
        /// <typeparam name="TPrimary">The primary entity type</typeparam>
        /// <param name="column">The foreign key column</param>
        /// <param name="primaryTableName">The primary table name</param>
        /// <param name="primaryColumnName">The primary table's column name</param>
        /// <param name="onDelete">Behavior for DELETEs</param>
        /// <returns>Alter/add a column with an optional foreign key</returns>
        public static IAlterTableColumnOptionOrAddColumnOrAlterColumnOrForeignKeyCascadeSyntax ForeignKey<TPrimary>(this IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax column, string primaryTableName = null, string primaryColumnName = null, Rule onDelete = Rule.Cascade) where TPrimary : BaseEntity
        {
            primaryTableName ??= typeof(TPrimary).Name;
            primaryColumnName ??= nameof(BaseEntity.Id);

            return column.Indexed().ForeignKey(primaryTableName, primaryColumnName).OnDelete(onDelete);
        }

        /// <summary>
        /// Retrieves expressions into ICreateExpressionRoot
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="expressionRoot">The root expression for a CREATE operation</param>
        public static void TableFor<TEntity>(this ICreateExpressionRoot expressionRoot) where TEntity : BaseEntity
        {
            var type = typeof(TEntity);
            var builder = expressionRoot.Table(type.Name) as CreateTableExpressionBuilder;
            builder.RetrieveTableExpressions(type);
        }

        /// <summary>
        /// Retrieves expressions for building an entity table
        /// </summary>
        /// <param name="builder">An expression builder for a FluentMigrator.Expressions.CreateTableExpression</param>
        /// <param name="type">Type of entity</param>
        public static void RetrieveTableExpressions(this CreateTableExpressionBuilder builder, Type type)
        {
            var expression = builder.Expression;

            // Add primary key if none exists
            if (!expression.Columns.Any(c => c.IsPrimaryKey))
            {
                var pk = new ColumnDefinition
                {
                    Name = nameof(BaseEntity.Id),
                    Type = DbType.Int32,
                    IsIdentity = true,
                    TableName = type.Name,
                    ModificationType = ColumnModificationType.Create,
                    IsPrimaryKey = true
                };
                expression.Columns.Insert(0, pk);
                builder.CurrentColumn = pk;
            }

            // Get properties to auto-map
            var propertiesToAutoMap = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty)
                .Where(pi => pi.DeclaringType != typeof(BaseEntity) &&
                             pi.CanWrite &&
                             !pi.HasAttribute<NotMappedAttribute>() &&
                             !pi.HasAttribute<NotColumnAttribute>() &&
                             !expression.Columns.Any(x => x.Name.Equals(pi.Name, StringComparison.OrdinalIgnoreCase)));

            foreach (var prop in propertiesToAutoMap)
            {
                var columnName = prop.Name;
                var (propType, canBeNullable) = GetTypeToMap(prop.PropertyType);

                if (TypeMapping.ContainsKey(propType))
                {
                    DefineByOwnType(columnName, propType, builder, canBeNullable);
                }
                else if (propType.IsEnum) // Handle enums directly
                {
                    builder.WithColumn(columnName).AsInt32();
                }
                else
                {
                    throw new InvalidOperationException($"Unsupported property type: {propType.Name} for column {columnName}");
                }
            }
        }

        /// <summary>
        /// Gets the type to map based on whether the property is nullable
        /// </summary>
        /// <param name="type">Property type</param>
        /// <returns>Tuple containing the type and whether it is nullable</returns>
        public static (Type propType, bool canBeNullable) GetTypeToMap(this Type type)
        {
            if (Nullable.GetUnderlyingType(type) is Type uType)
                return (uType, true);

            if (type.IsEnum)
                return (typeof(Enum), false); // Handle enums

            return (type, false);
        }
    }
}
