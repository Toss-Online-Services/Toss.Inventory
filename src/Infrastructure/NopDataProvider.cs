using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Data;

namespace Infrastructure
{
    public class NopDataProvider : INopDataProvider
    {
        public string ConfigurationName => throw new NotImplementedException();

        public int SupportedLengthOfBinaryHash => throw new NotImplementedException();

        public bool BackupSupported => throw new NotImplementedException();

        public Task BackupDatabaseAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public string BuildConnectionString(INopConnectionStringInfo nopConnectionString)
        {
            throw new NotImplementedException();
        }

        public void BulkDeleteEntities<TEntity>(IList<TEntity> entities) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public int BulkDeleteEntities<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task BulkDeleteEntitiesAsync<TEntity>(IList<TEntity> entities) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<int> BulkDeleteEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void BulkInsertEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task BulkInsertEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void CreateDatabase(string collation, int triesToConnect = 10)
        {
            throw new NotImplementedException();
        }

        public string CreateForeignKeyName(string foreignTable, string foreignColumn, string primaryTable, string primaryColumn)
        {
            throw new NotImplementedException();
        }

        public Task<ITempDataStorage<TItem>> CreateTempDataStorageAsync<TItem>(string storeKey, IQueryable<TItem> query) where TItem : class
        {
            throw new NotImplementedException();
        }

        public bool DatabaseExists()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DatabaseExistsAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteNonQueryAsync(string sql, params DataParameter[] dataParameters)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<int, string>> GetFieldHashesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> keySelector, Expression<Func<TEntity, object>> fieldSelector) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public string GetIndexName(string targetTable, string targetColumn)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetTable<TEntity>() where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetTableIdentAsync<TEntity>() where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void InitializeDatabase()
        {
            throw new NotImplementedException();
        }

        public TEntity InsertEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> QueryAsync<T>(string sql, params DataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> QueryProcAsync<T>(string procedureName, params DataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task ReIndexTablesAsync()
        {
            throw new NotImplementedException();
        }

        public Task RestoreDatabaseAsync(string backupFileName)
        {
            throw new NotImplementedException();
        }

        public Task SetTableIdentAsync<TEntity>(int ident) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task TruncateAsync<TEntity>(bool resetIdentity = false) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void UpdateEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
