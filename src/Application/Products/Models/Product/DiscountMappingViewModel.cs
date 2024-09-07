namespace Application.Products.Models.Product;


/// <param name="Id"> Gets the entity identifier </param>
/// <param name="DiscountId"> Gets or sets the discount identifier </param>
public abstract record DiscountMappingViewModel(int Id, int DiscountId);
