namespace Application.Product.Products.Queries.GetProductVideosByProductId;

public record GetProductVideosByProductIdQuery : IRequest<CommandResult<List<ProductVideo>>>
{
}

public class GetProductVideosByProductIdQueryValidator : AbstractValidator<GetProductVideosByProductIdQuery>
{
    public GetProductVideosByProductIdQueryValidator()
    {
    }
}

public class GetProductVideosByProductIdQueryHandler : IRequestHandler<GetProductVideosByProductIdQuery, CommandResult<List<ProductVideo>>>
{
    private readonly IProductRepository _context;

    public GetProductVideosByProductIdQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<ProductVideo>>> Handle(GetProductVideosByProductIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
