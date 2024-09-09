namespace Domain.Entities;

public interface IProductRepository : IRepository<Product>
{
    Product Add(Product product);

    void Update(Product product);

    Task<Product> GetAsync(int productId);
    IQueryable<Product> GetAllAsync();
}
