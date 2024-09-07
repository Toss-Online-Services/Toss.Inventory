namespace Application.Products.Models.Product;





/// <summary>
/// Represents a discount requirement
/// </summary>
/// <param name="DiscountId"> Gets or sets the discount identifier </param>
/// <param name="DiscountRequirementRuleSystemName"> Gets or sets the discount requirement rule system name </param>
/// <param name="ParentId"> Gets or sets the parent requirement identifier </param>
/// <param name="InteractionTypeId"> Gets or sets an interaction type identifier (has a value for the group and null for the child requirements) </param>
/// <param name="IsGroup"> Gets or sets a value indicating whether this requirement has any child requirements </param>
public record DiscountRequirementViewModel(int DiscountId, string DiscountRequirementRuleSystemName, int? ParentId, int? InteractionTypeId, bool IsGroup);
