using System.Linq.Expressions;
using Domain.Common;
using Domain.Entities.Catalog;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public void Delete(Product entity, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }

    public int Delete(Expression<Func<Product, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity, bool publishEvent = true)
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

    public void Insert(Product entity, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }

    public void Insert(IList<Product> entities, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }


    public Product Add(Product product)
    {
        if (product.IsTransient())
        {
            return _context.Products
                .Add(product)
                .Entity;
        }

        return product;
    }


    public Task InsertAsync(IList<Product> entities, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }

    public void Update(IList<Product> entities, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IList<Product> entities, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }

    public Product Insert(Product product)
    {
        if (product.IsTransient())
        {
            return _context.Products
                .Add(product)
                .Entity;
        }

        return product;
    }

    public Task<Product> InsertAsync(Product entity, bool publishEvent = true)
    {
        throw new NotImplementedException();
    }
}
