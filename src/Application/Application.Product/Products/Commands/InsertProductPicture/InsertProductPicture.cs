namespace Application.Product.Products.Commands.InsertProductPicture;

public record InsertProductPictureCommand : IRequest<CommandResult<int>>
{
}

public class InsertProductPictureCommandValidator : AbstractValidator<InsertProductPictureCommand>
{
    public InsertProductPictureCommandValidator()
    {
    }
}

public class InsertProductPictureCommandHandler : IRequestHandler<InsertProductPictureCommand, CommandResult<int>>
{
    private readonly IProductRepository _context;

    public InsertProductPictureCommandHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<int>> Handle(InsertProductPictureCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
