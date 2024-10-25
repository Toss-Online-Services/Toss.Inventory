using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Admin.Factories;

namespace Toss.Api.Admin.Components;

/// <summary>
/// Represents a view component that displays the admin language selector
/// </summary>
public partial class AdminLanguageSelectorViewComponent : NopViewComponent
{
    #region Fields

    protected readonly ICommonModelFactory _commonModelFactory;

    #endregion

    #region Ctor

    public AdminLanguageSelectorViewComponent(ICommonModelFactory commonModelFactory)
    {
        _commonModelFactory = commonModelFactory;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Invoke view component
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the view component result
    /// </returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
        //prepare model
        var model = await _commonModelFactory.PrepareLanguageSelectorModelAsync();

        return View(model);
    }

    #endregion
}