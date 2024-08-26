namespace Application.Product.Products.Commands.DeleteTierPrice;

public record DeleteTierPriceCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteTierPriceCommandValidator : AbstractValidator<DeleteTierPriceCommand>
{
    public DeleteTierPriceCommandValidator()
    {
    }
}

public class DeleteTierPriceCommandHandler : IRequestHandler<DeleteTierPriceCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteTierPriceCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteTierPriceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
