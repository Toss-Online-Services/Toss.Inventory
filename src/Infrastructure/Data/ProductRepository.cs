using System.Linq.Expressions;
using Domain.Entities;
using Domain.SeedWork;
using Infrastructure.Caching;

namespace Toss.Inventory.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public IUnitOfWork UnitOfWork => _context;
        public ProductRepository()
        {

        }

        public ProductRepository(CatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Product Add(Product product)
        {
            return _context.Products.Add(product).Entity;
        }

        public Task<Product> GetByIdAsync(int? id, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true, bool useShortTermCache = false)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int? id, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetByIdsAsync(IList<int> ids, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllAsync(Func<IQueryable<Product>, Task<IQueryable<Product>>> func = null, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll(Func<IQueryable<Product>, IQueryable<Product>> func = null, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetAllAsync(Func<IQueryable<Product>, Task<IQueryable<Product>>> func, Func<ICacheKeyService, Task<CacheKey>> getCacheKey, bool includeDeleted = true)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Product>> GetAllPagedAsync(Func<IQueryable<Product>, IQueryable<Product>> func = null, int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false, bool includeDeleted = true)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Product>> GetAllPagedAsync(Func<IQueryable<Product>, Task<IQueryable<Product>>> func = null, int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false, bool includeDeleted = true)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Product entity, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product entity, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(IList<Product> entities, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public void Insert(IList<Product> entities, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IList<Product> entities, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<Product> entities, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IList<Product> entities, bool publishEvent = true)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Product> LoadOriginalCopyAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task TruncateAsync(bool resetIdentity = false)
        {
            throw new NotImplementedException();
        }
    }
}
