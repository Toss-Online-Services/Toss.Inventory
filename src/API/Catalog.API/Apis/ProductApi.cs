using Application.Features.Product.Products.Commands.CreateProduct;
using Application.Infrastructure.Models;
using Catalog.API.Infrastructure;
using Domain.Entities.Product.Commands;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace Catalog.API.Apis;

public class ProductApi : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateProduct);
    }
    public Task<int> CreateProduct(ISender sender, CreateProductRequest request)
    {
        return sender.Send(request);
    }
}
