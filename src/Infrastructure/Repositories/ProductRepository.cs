
namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ProductRepository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Product Add(Product product)
    {
        return _context.Products.Add(product).Entity;

    }

    public async Task<Product> GetAsync(int productId)
    {
        var product = await _context.Products.FindAsync(productId);

        //if (product != null)
        //{
        //    await _context.Entry(product).Collection(i => i.ProductItems).LoadAsync();
        //}

        return product;
    }

    public void Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
}
