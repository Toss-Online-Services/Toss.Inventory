namespace Application.Product.Products.Commands.ClearDiscountProductMapping;

public record ClearDiscountProductMappingCommand : IRequest<CommandResult<bool>>
{
}

public class ClearDiscountProductMappingCommandValidator : AbstractValidator<ClearDiscountProductMappingCommand>
{
    public ClearDiscountProductMappingCommandValidator()
    {
    }
}

public class ClearDiscountProductMappingCommandHandler : IRequestHandler<ClearDiscountProductMappingCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public ClearDiscountProductMappingCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(ClearDiscountProductMappingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
