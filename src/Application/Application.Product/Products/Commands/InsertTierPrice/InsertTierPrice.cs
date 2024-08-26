namespace Application.Product.Products.Commands.InsertTierPrice;

public record InsertTierPriceCommand : IRequest<CommandResult<int>>
{
}

public class InsertTierPriceCommandValidator : AbstractValidator<InsertTierPriceCommand>
{
    public InsertTierPriceCommandValidator()
    {
    }
}

public class InsertTierPriceCommandHandler : IRequestHandler<InsertTierPriceCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertTierPriceCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertTierPriceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
