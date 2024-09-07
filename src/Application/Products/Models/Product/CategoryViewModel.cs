namespace Application.Products.Models.Product;
























/// <summary>
/// Represents a category
/// </summary>
/// <param name="Name"> Gets or sets the name </param>
/// <param name="Description"> Gets or sets the description </param>
/// <param name="CategoryTemplateId"> Gets or sets a value of used category template identifier </param>
/// <param name="MetaKeywords"> Gets or sets the meta keywords </param>
/// <param name="MetaDescription"> Gets or sets the meta description </param>
/// <param name="MetaTitle"> Gets or sets the meta title </param>
/// <param name="ParentCategoryId"> Gets or sets the parent category identifier </param>
/// <param name="PictureId"> Gets or sets the picture identifier </param>
/// <param name="PageSize"> Gets or sets the page size </param>
/// <param name="AllowCustomersToSelectPageSize"> Gets or sets a value indicating whether customers can select the page size </param>
/// <param name="PageSizeOptions"> Gets or sets the available customer selectable page size options </param>
/// <param name="ShowOnHomepage"> Gets or sets a value indicating whether to show the category on home page </param>
/// <param name="IncludeInTopMenu"> Gets or sets a value indicating whether to include this category in the top menu </param>
/// <param name="SubjectToAcl"> Gets or sets a value indicating whether the entity is subject to ACL </param>
/// <param name="LimitedToStores"> Gets or sets a value indicating whether the entity is limited/restricted to certain stores </param>
/// <param name="Published"> Gets or sets a value indicating whether the entity is published </param>
/// <param name="Deleted"> Gets or sets a value indicating whether the entity has been deleted </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
/// <param name="CreatedOnUtc"> Gets or sets the date and time of instance creation </param>
/// <param name="UpdatedOnUtc"> Gets or sets the date and time of instance update </param>
/// <param name="PriceRangeFiltering"> Gets or sets a value indicating whether the price range filtering is enabled </param>
/// <param name="PriceFrom"> Gets or sets the "from" price </param>
/// <param name="PriceTo"> Gets or sets the "to" price </param>
/// <param name="ManuallyPriceRange"> Gets or sets a value indicating whether the price range should be entered manually </param>
public record CategoryViewModel(string Name, string Description, int CategoryTemplateId, string MetaKeywords, string MetaDescription, string MetaTitle, int ParentCategoryId, int PictureId, int PageSize, bool AllowCustomersToSelectPageSize, string PageSizeOptions, bool ShowOnHomepage, bool IncludeInTopMenu, bool SubjectToAcl, bool LimitedToStores, bool Published, bool Deleted, int DisplayOrder, DateTime CreatedOnUtc, DateTime UpdatedOnUtc, bool PriceRangeFiltering, decimal PriceFrom, decimal PriceTo, bool ManuallyPriceRange);
