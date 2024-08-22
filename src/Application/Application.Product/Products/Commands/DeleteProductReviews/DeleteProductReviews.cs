namespace Application.Product.Products.Commands.DeleteProductReviews;

public record DeleteProductReviewsCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteProductReviewsCommandValidator : AbstractValidator<DeleteProductReviewsCommand>
{
    public DeleteProductReviewsCommandValidator()
    {
    }
}

public class DeleteProductReviewsCommandHandler : IRequestHandler<DeleteProductReviewsCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteProductReviewsCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteProductReviewsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
