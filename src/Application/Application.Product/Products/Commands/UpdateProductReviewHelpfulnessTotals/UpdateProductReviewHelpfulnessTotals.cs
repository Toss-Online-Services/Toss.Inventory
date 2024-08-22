namespace Application.Product.Products.Commands.UpdateProductReviewHelpfulnessTotals;

public record UpdateProductReviewHelpfulnessTotalsCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductReviewHelpfulnessTotalsCommandValidator : AbstractValidator<UpdateProductReviewHelpfulnessTotalsCommand>
{
    public UpdateProductReviewHelpfulnessTotalsCommandValidator()
    {
    }
}

public class UpdateProductReviewHelpfulnessTotalsCommandHandler : IRequestHandler<UpdateProductReviewHelpfulnessTotalsCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductReviewHelpfulnessTotalsCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductReviewHelpfulnessTotalsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
