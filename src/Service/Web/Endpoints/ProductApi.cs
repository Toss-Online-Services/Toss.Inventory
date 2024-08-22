﻿using Application.Features.Products.Commands.CreateProduct;
using Web.Infrastructure;

namespace Web.Endpoints;

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
