namespace Application.Product.Products.Commands.UpdateTierPrice;

public record UpdateTierPriceCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateTierPriceCommandValidator : AbstractValidator<UpdateTierPriceCommand>
{
    public UpdateTierPriceCommandValidator()
    {
    }
}

public class UpdateTierPriceCommandHandler : IRequestHandler<UpdateTierPriceCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateTierPriceCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateTierPriceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
