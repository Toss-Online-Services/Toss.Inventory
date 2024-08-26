namespace Application.Product.Products.Queries.GetAllProductReviews;

public record GetAllProductReviewsQuery : IRequest<CommandResult<IPagedList<ProductReview>>>
{
}

public class GetAllProductReviewsQueryValidator : AbstractValidator<GetAllProductReviewsQuery>
{
    public GetAllProductReviewsQueryValidator()
    {
    }
}

public class GetAllProductReviewsQueryHandler : IRequestHandler<GetAllProductReviewsQuery, CommandResult<IPagedList<ProductReview>>>
{
    private readonly IProductRepository _context;

    public GetAllProductReviewsQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<IPagedList<ProductReview>>> Handle(GetAllProductReviewsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
