using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Toss.Api.Factories;

namespace Toss.Api.Components;

public partial class ExternalMethodsViewComponent : NopViewComponent
{
    #region Fields

    protected readonly IExternalAuthenticationModelFactory _externalAuthenticationModelFactory;

    #endregion

    #region Ctor

    public ExternalMethodsViewComponent(IExternalAuthenticationModelFactory externalAuthenticationModelFactory)
    {
        _externalAuthenticationModelFactory = externalAuthenticationModelFactory;
    }

    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _externalAuthenticationModelFactory.PrepareExternalMethodsModelAsync();

        return View(model);
    }

    #endregion
}