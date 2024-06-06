namespace Domain.Entities.Product;
public record UpdatePhysicalAttributesRequest : IRequest<bool>
{
    public decimal Weight { get; init; }
    public decimal Length { get; init; }
    public decimal Width { get; init; }
    public decimal Height { get; init; }
    public string Color { get; init; }
    public string Material { get; init; }
    public string Size { get; init; }
    public string PackagingType { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdatePhysicalAttributesRequest, UpdatePhysicalAttributesCommand>();
        }
    }
}

