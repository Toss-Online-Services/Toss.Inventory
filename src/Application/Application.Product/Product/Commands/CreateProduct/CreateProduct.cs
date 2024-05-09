namespace Application.Product.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _context;

    public CreateProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(500);
        return 1;
    }
}
