using Microsoft.AspNetCore.Mvc;
using Nop.Core.Http.Extensions;
using Nop.Services.Media;

namespace Nop.Web.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public partial class PictureController : ControllerBase
    {
        #region Fields

        private readonly IPictureService _pictureService;

        #endregion

        #region Ctor

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        #endregion

        #region Methods

        [HttpPost("async-upload")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AsyncUpload()
        {
            var httpPostedFile = await Request.GetFirstOrDefaultFileAsync();
            if (httpPostedFile == null)
                return BadRequest(new { success = false, message = "No file uploaded" });

            var picture = await _pictureService.InsertPictureAsync(httpPostedFile);

            if (picture == null)
                return BadRequest(new { success = false, message = "Wrong file format" });

            return Ok(new
            {
                success = true,
                pictureId = picture.Id,
                imageUrl = (await _pictureService.GetPictureUrlAsync(picture, 100)).Url
            });
        }

        #endregion
    }
}
