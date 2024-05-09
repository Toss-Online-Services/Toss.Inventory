using Application.Product.Products.Commands.InsertProduct;

namespace Toss.Inventory.Catalog.Web.Endpoints;

public class Product : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateProduct);
    }
    public Task<int> CreateProduct(ISender sender, InsertProductCommand command)
    {
        return sender.Send(command);
    }
}
