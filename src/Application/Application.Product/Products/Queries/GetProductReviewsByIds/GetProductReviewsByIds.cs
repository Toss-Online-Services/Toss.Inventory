namespace Application.Product.Products.Queries.GetProductReviewsByIds;

public record GetProductReviewsByIdsQuery : IRequest<CommandResult<List<ProductReview>>>
{
}

public class GetProductReviewsByIdsQueryValidator : AbstractValidator<GetProductReviewsByIdsQuery>
{
    public GetProductReviewsByIdsQueryValidator()
    {
    }
}

public class GetProductReviewsByIdsQueryHandler : IRequestHandler<GetProductReviewsByIdsQuery, CommandResult<List<ProductReview>>>
{
    private readonly IProductRepository _context;

    public GetProductReviewsByIdsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<ProductReview>>> Handle(GetProductReviewsByIdsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
