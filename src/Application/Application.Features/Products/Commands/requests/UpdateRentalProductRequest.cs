using Domain.Infrastructure;

namespace Domain.Entities.Product;
public record UpdateRentalProductRequest : IRequest<bool>
{
    public bool IsRental { get; init; }
    public int RentalPriceLength { get; init; }
    public int RentalPricePeriodId { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRentalProductRequest, UpdateRentalProductCommand>();
        }
    }
}
