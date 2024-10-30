using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Services.Media.RoxyFileman;
using Nop.Services.Security;
using System;
using Toss.Api.Admin.Models.Media;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/roxyfileman")]
    [ApiController]
    public class RoxyFilemanController : ControllerBase
    {
        #region Fields

        private readonly IPermissionService _permissionService;
        private readonly IRoxyFilemanService _roxyFilemanService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public RoxyFilemanController(IPermissionService permissionService, IRoxyFilemanService roxyFilemanService, IWebHelper webHelper)
        {
            _permissionService = permissionService;
            _roxyFilemanService = roxyFilemanService;
            _webHelper = webHelper;
        }

        #endregion

        #region Utilities
               

        #endregion

        #region Methods

        [HttpPost("configure")]
        public async Task<IActionResult> CreateConfiguration()
        {
            var currentPathBase = Request.PathBase.ToString();
            await _roxyFilemanService.ConfigureAsync(currentPathBase);
            return Ok();
        }

        [HttpGet("directories")]
        public async Task<IActionResult> DirectoriesList(string type)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return BadRequest("You don't have required permission");

            var directories = _roxyFilemanService.GetDirectoryList(type);
            return Ok(directories);
        }

        [HttpGet("files")]
        public async Task<IActionResult> FilesList(string d, string type)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            var files = _roxyFilemanService.GetFiles(d, type);
            return Ok(files);
        }

        [HttpGet("file/download")]
        public async Task<IActionResult> DownloadFile(string f)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            var (stream, name) = _roxyFilemanService.GetFileStream(f);

            if (!new FileExtensionContentTypeProvider().TryGetContentType(f, out var contentType))
                contentType = MimeTypes.ApplicationOctetStream;

            return File(stream, contentType, name);
        }

        [HttpPost("directory/copy")]
        public async Task<IActionResult> CopyDirectory(string d, string n)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.CopyDirectory(d, n);
            return Ok();
        }

        [HttpPost("file/copy")]
        public async Task<IActionResult> CopyFile(string f, string n)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.CopyFile(f, n);
            return Ok();
        }

        [HttpPost("directory/create")]
        public async Task<IActionResult> CreateDirectory(string d, string n)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.CreateDirectory(d, n);
            return Ok();
        }

        [HttpDelete("directory/delete")]
        public async Task<IActionResult> DeleteDirectory(string d)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.DeleteDirectory(d);
            return Ok();
        }

        [HttpDelete("file/delete")]
        public async Task<IActionResult> DeleteFile(string f)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.DeleteFile(f);
            return Ok();
        }

        [HttpGet("directory/download")]
        public async Task<IActionResult> DownloadDirectory(string d)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            var fileContents = _roxyFilemanService.DownloadDirectory(d);
            return File(fileContents, MimeTypes.ApplicationZip);
        }

        [HttpPost("directory/move")]
        public async Task<IActionResult> MoveDirectory(string d, string n)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.MoveDirectory(d, n);
            return Ok();
        }

        [HttpPost("file/move")]
        public async Task<IActionResult> MoveFile(string f, string n)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.MoveFile(f, n);
            return Ok();
        }

        [HttpPost("directory/rename")]
        public async Task<IActionResult> RenameDirectory(string d, string n)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.RenameDirectory(d, n);
            return Ok();
        }

        [HttpPost("file/rename")]
        public async Task<IActionResult> RenameFile(string f, string n)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            _roxyFilemanService.RenameFile(f, n);
            return Ok();
        }

        [HttpGet("image/thumbnail")]
        public async Task<IActionResult> CreateImageThumbnail(string f)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            if (!new FileExtensionContentTypeProvider().TryGetContentType(f, out var contentType))
                contentType = MimeTypes.ImageJpeg;

            var fileContents = _roxyFilemanService.CreateImageThumbnail(f, contentType);
            return File(fileContents, contentType);
        }

        [HttpPost("files/upload")]
        public async Task<IActionResult> UploadFiles([FromForm] RoxyFilemanUploadModel uploadModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.System.HTML_EDITOR_MANAGE_PICTURES))
                return Forbid("You don't have required permission");

            var form = await HttpContext.Request.ReadFormAsync();

            if (!form.Files.Any())
                return BadRequest("No files uploaded");

            await _roxyFilemanService.UploadFilesAsync(uploadModel.D, form.Files);
            return Ok();
        }

        #endregion
    }
}
