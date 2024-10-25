using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Toss.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpGet("FallbackRedirect")]
        public IActionResult FallbackRedirect()
        {
            // Logic for handling fallback
            return Ok("Fallback executed");
        }
    }
}
