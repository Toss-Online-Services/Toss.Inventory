namespace Application.Product.Products.Commands.InsertProductReview;

public record InsertProductReviewCommand : IRequest<CommandResult<int>>
{
}

public class InsertProductReviewCommandValidator : AbstractValidator<InsertProductReviewCommand>
{
    public InsertProductReviewCommandValidator()
    {
    }
}

public class InsertProductReviewCommandHandler : IRequestHandler<InsertProductReviewCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertProductReviewCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertProductReviewCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
