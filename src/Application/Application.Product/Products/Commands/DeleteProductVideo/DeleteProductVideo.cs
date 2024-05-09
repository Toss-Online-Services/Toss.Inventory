namespace Application.Product.Products.Commands.DeleteProductVideo;

public record DeleteProductVideoCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteProductVideoCommandValidator : AbstractValidator<DeleteProductVideoCommand>
{
    public DeleteProductVideoCommandValidator()
    {
    }
}

public class DeleteProductVideoCommandHandler : IRequestHandler<DeleteProductVideoCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteProductVideoCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteProductVideoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
