namespace Application.Product.Products.Commands.UpdateProductReviewTotals;

public record UpdateProductReviewTotalsCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductReviewTotalsCommandValidator : AbstractValidator<UpdateProductReviewTotalsCommand>
{
    public UpdateProductReviewTotalsCommandValidator()
    {
    }
}

public class UpdateProductReviewTotalsCommandHandler : IRequestHandler<UpdateProductReviewTotalsCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductReviewTotalsCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductReviewTotalsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
