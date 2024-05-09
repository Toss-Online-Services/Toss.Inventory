namespace Application.Product.Products.Commands.UpdateProductReview;

public record UpdateProductReviewCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductReviewCommandValidator : AbstractValidator<UpdateProductReviewCommand>
{
    public UpdateProductReviewCommandValidator()
    {
    }
}

public class UpdateProductReviewCommandHandler : IRequestHandler<UpdateProductReviewCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductReviewCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductReviewCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
