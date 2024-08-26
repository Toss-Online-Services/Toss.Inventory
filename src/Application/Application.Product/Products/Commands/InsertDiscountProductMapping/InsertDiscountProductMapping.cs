namespace Application.Product.Products.Commands.InsertDiscountProductMapping;

public record InsertDiscountProductMappingCommand : IRequest<CommandResult<int>>
{
}

public class InsertDiscountProductMappingCommandValidator : AbstractValidator<InsertDiscountProductMappingCommand>
{
    public InsertDiscountProductMappingCommandValidator()
    {
    }
}

public class InsertDiscountProductMappingCommandHandler : IRequestHandler<InsertDiscountProductMappingCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertDiscountProductMappingCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertDiscountProductMappingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
