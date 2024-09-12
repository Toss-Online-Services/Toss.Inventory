namespace Domain.Services.Discounts;

/// <summary>
/// Represents a discount requirement plugin manager
/// </summary>
public partial interface IDiscountPluginManager : IPluginManager<IDiscountRequirementRule>
{
}