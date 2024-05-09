using Application.Product.Models;
using AutoMapper;

namespace Application.Product.Products.Commands.InsertProduct;

public record InsertProductCommand : IRequest<int>
{
    public ProductModel Product { get; set; }
}

public class InsertProductCommandValidator : AbstractValidator<InsertProductCommand>
{
    public InsertProductCommandValidator()
    {
    }
}

public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, int>
{
    private readonly IProductRepository _context;
    private readonly IMapper _mapper;

    public InsertProductCommandHandler(IProductRepository context,  IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(InsertProductCommand request, CancellationToken cancellationToken)
    {
        return await _context.InsertAsync(_mapper.Map<Domain.Entities.Products.Product>(request.Product));
    }
}
