namespace Application.Product.Products.Commands.UpdateHasTierPricesProperty;

public record UpdateHasTierPricesPropertyCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateHasTierPricesPropertyCommandValidator : AbstractValidator<UpdateHasTierPricesPropertyCommand>
{
    public UpdateHasTierPricesPropertyCommandValidator()
    {
    }
}

public class UpdateHasTierPricesPropertyCommandHandler : IRequestHandler<UpdateHasTierPricesPropertyCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateHasTierPricesPropertyCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateHasTierPricesPropertyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
