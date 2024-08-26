namespace Application.Product.Products.Queries.GetProductPicturesByProductId;

public record GetProductPicturesByProductIdQuery : IRequest<CommandResult<List<ProductPicture>>>
{
}

public class GetProductPicturesByProductIdQueryValidator : AbstractValidator<GetProductPicturesByProductIdQuery>
{
    public GetProductPicturesByProductIdQueryValidator()
    {
    }
}

public class GetProductPicturesByProductIdQueryHandler : IRequestHandler<GetProductPicturesByProductIdQuery, CommandResult<List<ProductPicture>>>
{
    private readonly IProductRepository _context;

    public GetProductPicturesByProductIdQueryHandler(IProductRepository context)
    {
        _context = context;
    }

    public async Task<CommandResult<List<ProductPicture>>> Handle(GetProductPicturesByProductIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
