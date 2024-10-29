using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Common;

namespace Toss.Api.Admin.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public partial class PreferencesController : ControllerBase
{
    #region Fields

    private readonly IGenericAttributeService _genericAttributeService;
    private readonly IWorkContext _workContext;

    #endregion

    #region Constructor

    public PreferencesController(IGenericAttributeService genericAttributeService,
        IWorkContext workContext)
    {
        _genericAttributeService = genericAttributeService;
        _workContext = workContext;
    }

    #endregion

    #region Methods

    [HttpPost("save-preference")]
    public async Task<IActionResult> SavePreference([FromQuery] string name, [FromQuery] bool value)
    {
        // Permission validation is not required here
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Preference name cannot be null or empty.", nameof(name));

        var customer = await _workContext.GetCurrentCustomerAsync();
        await _genericAttributeService.SaveAttributeAsync(customer, name, value);

        return Ok(new { Result = true });
    }

    #endregion
}
