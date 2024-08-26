namespace Application.Product.Products.Queries.GetProductById;

public record GetProductByIdQuery : IRequest<CommandResult<Product>>
{
}

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
    }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, CommandResult<Product>>
{
    private readonly IProductRepository _context;

    public GetProductByIdQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
