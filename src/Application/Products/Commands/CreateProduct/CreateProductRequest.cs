using Application.Products.Commands.Requests;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductRequest : ProductCommand, IRequest<int>
{
    public UpdatePriceRequest Price { get; init; }
    public UpdateAvailabilityRequest Availability { get; init; }
    public UpdateInventoryRequest Inventory { get; init; }
    public UpdateShippingRequest Shipping { get; init; }
    public UpdateTaxRequest Tax { get; init; }
    public UpdateDownloadableProductRequest DownloadableProduct { get; init; }
    public UpdateGiftCardRequest GiftCard { get; init; }
    public UpdateRecurringProductRequest RecurringProduct { get; init; }
    public UpdateRentalProductRequest RentalProduct { get; init; }
    public UpdatePhysicalAttributesRequest PhysicalAttributes { get; init; }
    public UpdateComplianceAndStandardsRequest ComplianceAndStandards { get; init; }
    public UpdateLifecycleRequest Lifecycle { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
        }
    }

}


