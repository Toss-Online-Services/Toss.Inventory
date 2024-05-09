namespace Application.Product.Products.Queries.GetProductVideoById;

public record GetProductVideoByIdQuery : IRequest<CommandResult<ProductVideo>>
{
}

public class GetProductVideoByIdQueryValidator : AbstractValidator<GetProductVideoByIdQuery>
{
    public GetProductVideoByIdQueryValidator()
    {
    }
}

public class GetProductVideoByIdQueryHandler : IRequestHandler<GetProductVideoByIdQuery, CommandResult<ProductVideo>>
{
    private readonly IProductRepository _context;

    public GetProductVideoByIdQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<ProductVideo>> Handle(GetProductVideoByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
