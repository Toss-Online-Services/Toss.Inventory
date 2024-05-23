using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class PhysicalAttributes : ValueObject
{
    public decimal Weight { get; set; }
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public string Color { get; set; }
    public string Material { get; set; }
    public string Size { get; set; }
    public string PackagingType { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Weight;
        yield return Length;
        yield return Width;
        yield return Height;
        yield return Color;
        yield return Material;
        yield return Size;
        yield return PackagingType;
    }
}

