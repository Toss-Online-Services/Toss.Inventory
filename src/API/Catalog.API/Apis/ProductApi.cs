using Application.Features.Product.Products.Commands.CreateProduct;
using Catalog.API.Infrastructure;
using MediatR;

namespace Catalog.API.Apis;

public class ProductApi : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateProduct);
    }
    public Task<bool> CreateProduct(ISender sender, CreateProductRequest request)
    {
        return sender.Send(request);
    }
}
