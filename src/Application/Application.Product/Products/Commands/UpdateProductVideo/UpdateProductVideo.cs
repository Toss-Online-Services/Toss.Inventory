namespace Application.Product.Products.Commands.UpdateProductVideo;

public record UpdateProductVideoCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductVideoCommandValidator : AbstractValidator<UpdateProductVideoCommand>
{
    public UpdateProductVideoCommandValidator()
    {
    }
}

public class UpdateProductVideoCommandHandler : IRequestHandler<UpdateProductVideoCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductVideoCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductVideoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
