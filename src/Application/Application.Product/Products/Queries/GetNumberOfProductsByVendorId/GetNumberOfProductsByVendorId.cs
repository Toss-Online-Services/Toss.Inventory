namespace Application.Product.Products.Queries.GetNumberOfProductsByVendorId;

public record GetNumberOfProductsByVendorIdQuery : IRequest<CommandResult<int>>
{
}

public class GetNumberOfProductsByVendorIdQueryValidator : AbstractValidator<GetNumberOfProductsByVendorIdQuery>
{
    public GetNumberOfProductsByVendorIdQueryValidator()
    {
    }
}

public class GetNumberOfProductsByVendorIdQueryHandler : IRequestHandler<GetNumberOfProductsByVendorIdQuery, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public GetNumberOfProductsByVendorIdQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(GetNumberOfProductsByVendorIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
