namespace Application.Product.Products.Commands.UpdateProductStoreMappings;

public record UpdateProductStoreMappingsCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductStoreMappingsCommandValidator : AbstractValidator<UpdateProductStoreMappingsCommand>
{
    public UpdateProductStoreMappingsCommandValidator()
    {
    }
}

public class UpdateProductStoreMappingsCommandHandler : IRequestHandler<UpdateProductStoreMappingsCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductStoreMappingsCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductStoreMappingsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
