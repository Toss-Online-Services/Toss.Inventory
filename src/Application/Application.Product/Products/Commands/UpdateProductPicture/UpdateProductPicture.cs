namespace Application.Product.Products.Commands.UpdateProductPicture;

public record UpdateProductPictureCommand : IRequest<CommandResult<bool>>
{
}

public class UpdateProductPictureCommandValidator : AbstractValidator<UpdateProductPictureCommand>
{
    public UpdateProductPictureCommandValidator()
    {
    }
}

public class UpdateProductPictureCommandHandler : IRequestHandler<UpdateProductPictureCommand, CommandResult<bool>>
{
    private readonly IProductRepository _context;

    public UpdateProductPictureCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<bool>> Handle(UpdateProductPictureCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
