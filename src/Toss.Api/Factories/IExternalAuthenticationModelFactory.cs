using Toss.Api.Models.Customer;

namespace Toss.Api.Factories;

/// <summary>
/// Represents the interface of the external authentication model factory
/// </summary>
public partial interface IExternalAuthenticationModelFactory
{
    /// <summary>
    /// Prepare the external authentication method model
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the list of the external authentication method model
    /// </returns>
    Task<List<ExternalAuthenticationMethodModel>> PrepareExternalMethodsModelAsync();
}