namespace Domain.Entities;
public class PhysicalAttributes : ValueObject
{
    public decimal Weight { get; private set; }
    public decimal Length { get; private set; }
    public decimal Width { get; private set; }
    public decimal Height { get; private set; }
    public string Color { get; private set; }
    public string Material { get; private set; }
    public string Size { get; private set; }
    public string PackagingType { get; private set; }

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

    internal void Apply(UpdatePhysicalAttributesCommand physicalAttributes)
    {
        Weight = physicalAttributes.Weight;
        Length = physicalAttributes.Length;
        Width = physicalAttributes.Width;
        Height = physicalAttributes.Height;
        Color = physicalAttributes.Color;
        Material = physicalAttributes.Material;
        Size = physicalAttributes.Size;
        PackagingType = physicalAttributes.PackagingType;
    }
}

