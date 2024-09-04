using Application;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.Requests;
using Application.Products.Models;
using Application.Products.Queries.GetProductsWithPagination;
using Web.Infrastructure;

namespace Web.Endpoints;

public class Products : EndpointGroupBase
{

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetProductsWithPagination)
            .MapPost(CreateProduct)
            .MapPut(UpdatePrice, "UpdatePrice/{id}")
            .MapPut(UpdateAvailability, "UpdateAvailability/{id}")
            .MapPut(UpdateInventory, "UpdateInventory/{id}")
            .MapPut(UpdateShipping, "UpdateShipping/{id}")
            .MapPut(UpdateTax, "UpdateTax/{id}")
            .MapPut(UpdateDownloadableProduct, "UpdateDownloadableProduct/{id}")
            .MapPut(UpdateGiftCard, "UpdateGiftCard/{id}")
            .MapPut(UpdateRecurringProduct, "UpdateRecurringProduct/{id}")
            .MapPut(UpdateRentalProduct, "UpdateRentalProduct/{id}")
            .MapPut(UpdatePhysicalAttributes, "UpdatePhysicalAttributes/{id}")
            .MapPut(UpdateComplianceAndStandards, "UpdateComplianceAndStandards/{id}")
            .MapPut(UpdateLifecycle, "UpdateLifecycle/{id}")
            .MapDelete(DeleteProduct, "DeleteProduct/{id}");
    }

    public Task<PaginatedList<ProductModel>> GetProductsWithPagination(ISender sender, [AsParameters] GetProductsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateProduct(ISender sender, CreateProductRequest command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateAvailability(ISender sender, int id, UpdateAvailabilityRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateInventory(ISender sender, int id, UpdateInventoryRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateShipping(ISender sender, int id, UpdateShippingRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateTax(ISender sender, int id, UpdateTaxRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateDownloadableProduct(ISender sender, int id, UpdateDownloadableProductRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdatePrice(ISender sender, int id, UpdatePriceRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateGiftCard(ISender sender, int id, UpdateGiftCardRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateRecurringProduct(ISender sender, int id, UpdateRecurringProductRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateRentalProduct(ISender sender, int id, UpdateRentalProductRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
    public async Task<IResult> UpdatePhysicalAttributes(ISender sender, int id, UpdatePhysicalAttributesRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateComplianceAndStandards(ISender sender, int id, UpdateComplianceAndStandardsRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateLifecycle(ISender sender, int id, UpdateLifecycleRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateProductDetail(ISender sender, int id, UpdateProductDetailRequest command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteProduct(ISender sender, int id)
    {
        await sender.Send(new DeleteProductRequest(id));
        return Results.NoContent();
    }
}
