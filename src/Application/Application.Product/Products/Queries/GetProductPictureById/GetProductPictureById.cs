namespace Application.Product.Products.Queries.GetProductPictureById;

public record GetProductPictureByIdQuery : IRequest<CommandResult<ProductPicture>>
{
}

public class GetProductPictureByIdQueryValidator : AbstractValidator<GetProductPictureByIdQuery>
{
    public GetProductPictureByIdQueryValidator()
    {
    }
}

public class GetProductPictureByIdQueryHandler : IRequestHandler<GetProductPictureByIdQuery, CommandResult<ProductPicture>>
{
    private readonly IProductRepository _context;

    public GetProductPictureByIdQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<ProductPicture>> Handle(GetProductPictureByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
