namespace Application.Product.Products.Queries.GetProductReviewById;

public record GetProductReviewByIdQuery : IRequest<CommandResult<ProductReview>>
{
}

public class GetProductReviewByIdQueryValidator : AbstractValidator<GetProductReviewByIdQuery>
{
    public GetProductReviewByIdQueryValidator()
    {
    }
}

public class GetProductReviewByIdQueryHandler : IRequestHandler<GetProductReviewByIdQuery, CommandResult<ProductReview>>
{
    private readonly IProductRepository _context;

    public GetProductReviewByIdQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<ProductReview>> Handle(GetProductReviewByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
