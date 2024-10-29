using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Media;
using Nop.Core.Http.Extensions;
using Nop.Core.Infrastructure;
using Nop.Services.Media;
using ILogger = Nop.Services.Logging.ILogger;

namespace Toss.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class DownloadController : ControllerBase
    {
        #region Fields

        private readonly IDownloadService _downloadService;
        private readonly ILogger _logger;
        private readonly INopFileProvider _fileProvider;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public DownloadController(IDownloadService downloadService,
            ILogger logger,
            INopFileProvider fileProvider,
            IWorkContext workContext)
        {
            _downloadService = downloadService;
            _logger = logger;
            _fileProvider = fileProvider;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [HttpGet("download-file")]
        public async Task<IActionResult> DownloadFile(Guid downloadGuid)
        {
            var download = await _downloadService.GetDownloadByGuidAsync(downloadGuid);
            if (download == null)
                return NotFound(new { message = "No download record found with the specified id" });

            if (download.UseDownloadUrl)
                return Redirect(download.DownloadUrl);

            if (download.DownloadBinary == null)
                return NotFound(new { message = $"Download data is not available anymore. Download ID={download.Id}" });

            var fileName = !string.IsNullOrWhiteSpace(download.Filename) ? download.Filename : download.Id.ToString();
            var contentType = !string.IsNullOrWhiteSpace(download.ContentType) ? download.ContentType : MimeTypes.ApplicationOctetStream;
            return File(download.DownloadBinary, contentType, fileName + download.Extension);
        }

        [HttpPost("save-download-url")]
        public async Task<IActionResult> SaveDownloadUrl([FromBody] string downloadUrl)
        {
            if (string.IsNullOrEmpty(downloadUrl))
                return BadRequest(new { success = false, message = "Please enter URL" });

            var download = new Download
            {
                DownloadGuid = Guid.NewGuid(),
                UseDownloadUrl = true,
                DownloadUrl = downloadUrl,
                IsNew = true
            };
            await _downloadService.InsertDownloadAsync(download);

            return Ok(new { success = true, downloadId = download.Id });
        }

        [HttpPost("async-upload")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AsyncUpload()
        {
            var httpPostedFile = await Request.GetFirstOrDefaultFileAsync();
            if (httpPostedFile == null)
                return BadRequest(new { success = false, message = "No file uploaded" });

            var fileBinary = await _downloadService.GetDownloadBitsAsync(httpPostedFile);
            var fileName = _fileProvider.GetFileName(httpPostedFile.FileName);
            var contentType = httpPostedFile.ContentType;
            var fileExtension = _fileProvider.GetFileExtension(fileName)?.ToLowerInvariant();

            var download = new Download
            {
                DownloadGuid = Guid.NewGuid(),
                UseDownloadUrl = false,
                DownloadBinary = fileBinary,
                ContentType = contentType,
                Filename = _fileProvider.GetFileNameWithoutExtension(fileName),
                Extension = fileExtension,
                IsNew = true
            };

            try
            {
                await _downloadService.InsertDownloadAsync(download);
                var downloadUrl = Url.Action("DownloadFile", new { downloadGuid = download.DownloadGuid });

                return Ok(new { success = true, downloadId = download.Id, downloadUrl });
            }
            catch (Exception exc)
            {
                await _logger.ErrorAsync(exc.Message, exc, await _workContext.GetCurrentCustomerAsync());
                return StatusCode(500, new { success = false, message = "File cannot be saved" });
            }
        }

        #endregion
    }
}
