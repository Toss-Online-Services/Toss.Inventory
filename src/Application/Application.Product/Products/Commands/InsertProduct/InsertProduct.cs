using Application.Product.Models;
using AutoMapper;

namespace Application.Product.Products.Commands.InsertProduct;

public record InsertProductCommand : IRequest<bool>
{
    public ProductModel Product { get; set; }
}

public class InsertProductCommandValidator : AbstractValidator<InsertProductCommand>
{
    public InsertProductCommandValidator()
    {
    }
}

public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, bool>
{
    private readonly IProductRepository _context;
    private readonly IMapper _mapper;

    public InsertProductCommandHandler(IProductRepository context,  IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(InsertProductCommand request, CancellationToken cancellationToken)
    {

        Domain.Entities.Catalog.Product product = _mapper.Map<Domain.Entities.Catalog.Product>(request.Product);

        _context.Add(product);

        return await _context.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
