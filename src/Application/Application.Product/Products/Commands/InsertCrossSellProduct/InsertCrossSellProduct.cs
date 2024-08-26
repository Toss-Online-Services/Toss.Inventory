namespace Application.Product.Products.Commands.InsertCrossSellProduct;

public record InsertCrossSellProductCommand : IRequest<CommandResult<int>>
{
}

public class InsertCrossSellProductCommandValidator : AbstractValidator<InsertCrossSellProductCommand>
{
    public InsertCrossSellProductCommandValidator()
    {
    }
}

public class InsertCrossSellProductCommandHandler : IRequestHandler<InsertCrossSellProductCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertCrossSellProductCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertCrossSellProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
