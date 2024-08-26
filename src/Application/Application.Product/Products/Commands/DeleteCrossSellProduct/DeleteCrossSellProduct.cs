namespace Application.Product.Products.Commands.DeleteCrossSellProduct;

public record DeleteCrossSellProductCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteCrossSellProductCommandValidator : AbstractValidator<DeleteCrossSellProductCommand>
{
    public DeleteCrossSellProductCommandValidator()
    {
    }
}

public class DeleteCrossSellProductCommandHandler : IRequestHandler<DeleteCrossSellProductCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteCrossSellProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteCrossSellProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
