namespace Application.Common.Interfaces;

/// <summary>
/// Represents localized locale model
/// </summary>
public partial interface ILocalizedLocaleModel
{
    /// <summary>
    /// Gets or sets the language identifier
    /// </summary>
    int LanguageId { get; set; }
}