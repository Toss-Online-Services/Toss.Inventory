using Application.Features.Products.Commands.CreateProduct;
using AutoMapper;
using Domain.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities.Product.Commands;

public record UpdateAvailabilityRequest : IRequest<bool>
{
    public DateTime? AvailableStartDateTimeUtc { get; init; }
    public DateTime? AvailableEndDateTimeUtc { get; init; }
    public bool AvailableForPreOrder { get; init; }
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; init; }
    public int ProductAvailabilityRangeId { get; init; }
    public int DeliveryDateId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateAvailabilityRequest, UpdateAvailabilityCommand>();
        }
    }

}
