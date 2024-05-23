namespace Domain.Infrastructure;
/// <summary>
/// Represents an entity which supports discounts
/// </summary>
public partial interface IDiscountSupported<T> where T : IDiscountMapping
{
    int Id { get; set; }
}
