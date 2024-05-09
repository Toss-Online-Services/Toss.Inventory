namespace Application.Product.Products.Queries.GetNumberOfProductsInCategory;

public record GetNumberOfProductsInCategoryQuery : IRequest<CommandResult<int>>
{
}

public class GetNumberOfProductsInCategoryQueryValidator : AbstractValidator<GetNumberOfProductsInCategoryQuery>
{
    public GetNumberOfProductsInCategoryQueryValidator()
    {
    }
}

public class GetNumberOfProductsInCategoryQueryHandler : IRequestHandler<GetNumberOfProductsInCategoryQuery, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public GetNumberOfProductsInCategoryQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(GetNumberOfProductsInCategoryQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
