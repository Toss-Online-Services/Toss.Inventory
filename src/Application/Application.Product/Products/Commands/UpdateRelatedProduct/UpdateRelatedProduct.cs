namespace Application.Product.Products.Commands.UpdateRelatedProduct;

public record UpdateRelatedProductCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateRelatedProductCommandValidator : AbstractValidator<UpdateRelatedProductCommand>
{
    public UpdateRelatedProductCommandValidator()
    {
    }
}

public class UpdateRelatedProductCommandHandler : IRequestHandler<UpdateRelatedProductCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateRelatedProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateRelatedProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
