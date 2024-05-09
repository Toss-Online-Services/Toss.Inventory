namespace Application.Product.Products.Commands.UpdateHasDiscountsApplied;

public record UpdateHasDiscountsAppliedCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateHasDiscountsAppliedCommandValidator : AbstractValidator<UpdateHasDiscountsAppliedCommand>
{
    public UpdateHasDiscountsAppliedCommandValidator()
    {
    }
}

public class UpdateHasDiscountsAppliedCommandHandler : IRequestHandler<UpdateHasDiscountsAppliedCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateHasDiscountsAppliedCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateHasDiscountsAppliedCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
