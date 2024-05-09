namespace Application.Product.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
    }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
