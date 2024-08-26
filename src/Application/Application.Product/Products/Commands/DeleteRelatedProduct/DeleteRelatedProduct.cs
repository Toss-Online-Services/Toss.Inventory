namespace Application.Product.Products.Commands.DeleteRelatedProduct;

public record DeleteRelatedProductCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteRelatedProductCommandValidator : AbstractValidator<DeleteRelatedProductCommand>
{
    public DeleteRelatedProductCommandValidator()
    {
    }
}

public class DeleteRelatedProductCommandHandler : IRequestHandler<DeleteRelatedProductCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteRelatedProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteRelatedProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
