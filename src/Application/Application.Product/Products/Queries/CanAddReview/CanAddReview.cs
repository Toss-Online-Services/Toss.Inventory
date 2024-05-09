namespace Application.Product.Products.Queries.CanAddReview;

public record CanAddReviewQuery : IRequest<CommandResult<bool>>
{
}

public class CanAddReviewQueryValidator : AbstractValidator<CanAddReviewQuery>
{
    public CanAddReviewQueryValidator()
    {
    }
}

public class CanAddReviewQueryHandler : IRequestHandler<CanAddReviewQuery, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public CanAddReviewQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public CommandResult<bool> Handle(CanAddReviewQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
