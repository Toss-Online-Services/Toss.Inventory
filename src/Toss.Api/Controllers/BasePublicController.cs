using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Toss.Api.Controllers;

[WwwRequirement]
[CheckLanguageSeoCode]
[CheckAccessPublicStore]
[CheckAccessClosedStore]
[CheckDiscountCoupon]
[CheckAffiliate]
public abstract partial class BasePublicController : BaseController
{
    protected virtual IActionResult InvokeHttp404()
    {
        Response.StatusCode = 404;
        return Ok(new EmptyResult());
    }
}
