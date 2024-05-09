namespace Application.Product.Products.Commands.DeleteDiscountProductMapping;

public record DeleteDiscountProductMappingCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteDiscountProductMappingCommandValidator : AbstractValidator<DeleteDiscountProductMappingCommand>
{
    public DeleteDiscountProductMappingCommandValidator()
    {
    }
}

public class DeleteDiscountProductMappingCommandHandler : IRequestHandler<DeleteDiscountProductMappingCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteDiscountProductMappingCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteDiscountProductMappingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
