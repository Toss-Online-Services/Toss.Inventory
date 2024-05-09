namespace Application.Product.Products.Commands.DeleteProductReview;

public record DeleteProductReviewCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteProductReviewCommandValidator : AbstractValidator<DeleteProductReviewCommand>
{
    public DeleteProductReviewCommandValidator()
    {
    }
}

public class DeleteProductReviewCommandHandler : IRequestHandler<DeleteProductReviewCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteProductReviewCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteProductReviewCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
