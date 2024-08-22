namespace Application.Product.Products.Commands.DeleteProductPicture;

public record DeleteProductPictureCommand : IRequest<CommandResult<bool>>
{
}

public class DeleteProductPictureCommandValidator : AbstractValidator<DeleteProductPictureCommand>
{
    public DeleteProductPictureCommandValidator()
    {
    }
}

public class DeleteProductPictureCommandHandler : IRequestHandler<DeleteProductPictureCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public DeleteProductPictureCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(DeleteProductPictureCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
