using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Vendors;
using Nop.Services.Attributes;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Vendors;
using Nop.Web.Framework.Mvc.Filters;
using System.Threading.Tasks;
using Toss.Api.Admin.Factories;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Models.Vendors;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/vendors")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        #region Fields

        private readonly IAddressService _addressService;
        private readonly IAttributeParser<AddressAttribute, AddressAttributeValue> _addressAttributeParser;
        private readonly IAttributeParser<VendorAttribute, VendorAttributeValue> _vendorAttributeParser;
        private readonly IAttributeService<VendorAttribute, VendorAttributeValue> _vendorAttributeService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IVendorModelFactory _vendorModelFactory;
        private readonly IVendorService _vendorService;
        private static readonly char[] _separator = new[] { ',' };

        #endregion

        #region Ctor

        public VendorController(
            IAddressService addressService,
            IAttributeParser<AddressAttribute, AddressAttributeValue> addressAttributeParser,
            IAttributeParser<VendorAttribute, VendorAttributeValue> vendorAttributeParser,
            IAttributeService<VendorAttribute, VendorAttributeValue> vendorAttributeService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IPictureService pictureService,
            IUrlRecordService urlRecordService,
            IVendorModelFactory vendorModelFactory,
            IVendorService vendorService)
        {
            _addressService = addressService;
            _addressAttributeParser = addressAttributeParser;
            _vendorAttributeParser = vendorAttributeParser;
            _vendorAttributeService = vendorAttributeService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _urlRecordService = urlRecordService;
            _vendorModelFactory = vendorModelFactory;
            _vendorService = vendorService;
        }

        #endregion

        #region Utilities

        private async Task UpdatePictureSeoNamesAsync(Vendor vendor)
        {
            var picture = await _pictureService.GetPictureByIdAsync(vendor.PictureId);
            if (picture != null)
                await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(vendor.Name));
        }

        private async Task UpdateLocalesAsync(Vendor vendor, VendorModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(vendor, x => x.Name, localized.Name, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(vendor, x => x.Description, localized.Description, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(vendor, x => x.MetaKeywords, localized.MetaKeywords, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(vendor, x => x.MetaDescription, localized.MetaDescription, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(vendor, x => x.MetaTitle, localized.MetaTitle, localized.LanguageId);

                var seName = await _urlRecordService.ValidateSeNameAsync(vendor, localized.SeName, localized.Name, false);
                await _urlRecordService.SaveSlugAsync(vendor, seName, localized.LanguageId);
            }
        }

        private async Task<string> ParseVendorAttributesAsync(IFormCollection form)
        {
            var attributesXml = string.Empty;
            var vendorAttributes = await _vendorAttributeService.GetAllAttributesAsync();
            foreach (var attribute in vendorAttributes)
            {
                var controlId = $"{NopVendorDefaults.VendorAttributePrefix}{attribute.Id}";
                if (form.TryGetValue(controlId, out var controlValue) && !StringValues.IsNullOrEmpty(controlValue))
                {
                    var selectedValues = controlValue.ToString().Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                    attributesXml = selectedValues.Aggregate(attributesXml, (current, value) =>
                        _vendorAttributeParser.AddAttribute(current, attribute, value));
                }
            }

            return attributesXml;
        }

        #endregion

        #region Vendor Endpoints

        [HttpGet]
        [CheckPermission(StandardPermission.Customers.VENDORS_VIEW)]
        public async Task<IActionResult> List(VendorSearchModel searchModel)
        {
            var model = await _vendorModelFactory.PrepareVendorListModelAsync(searchModel);
            return Ok(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Customers.VENDORS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Create(VendorModel model, IFormCollection form)
        {
            var vendorAttributesXml = await ParseVendorAttributesAsync(form);
            var warnings = (await _vendorAttributeParser.GetAttributeWarningsAsync(vendorAttributesXml)).ToList();
            if (warnings.Any())
            {
                foreach (var warning in warnings)
                    ModelState.AddModelError(string.Empty, warning);
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vendor = model.ToEntity<Vendor>();
            await _vendorService.InsertVendorAsync(vendor);
            await _genericAttributeService.SaveAttributeAsync(vendor, NopVendorDefaults.VendorAttributes, vendorAttributesXml);
            await UpdateLocalesAsync(vendor, model);
            await UpdatePictureSeoNamesAsync(vendor);

            return CreatedAtAction(nameof(Get), new { id = vendor.Id }, vendor);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.Customers.VENDORS_VIEW)]
        public async Task<IActionResult> Get(int id)
        {
            var vendor = await _vendorService.GetVendorByIdAsync(id);
            if (vendor == null || vendor.Deleted)
                return NotFound();

            var model = await _vendorModelFactory.PrepareVendorModelAsync(null, vendor);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.Customers.VENDORS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Edit(int id, VendorModel model, IFormCollection form)
        {
            var vendor = await _vendorService.GetVendorByIdAsync(id);
            if (vendor == null || vendor.Deleted)
                return NotFound();

            var vendorAttributesXml = await ParseVendorAttributesAsync(form);
            var warnings = (await _vendorAttributeParser.GetAttributeWarningsAsync(vendorAttributesXml)).ToList();
            if (warnings.Any())
            {
                foreach (var warning in warnings)
                    ModelState.AddModelError(string.Empty, warning);
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            vendor = model.ToEntity(vendor);
            await _vendorService.UpdateVendorAsync(vendor);
            await _genericAttributeService.SaveAttributeAsync(vendor, NopVendorDefaults.VendorAttributes, vendorAttributesXml);
            await UpdateLocalesAsync(vendor, model);
            await UpdatePictureSeoNamesAsync(vendor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.Customers.VENDORS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var vendor = await _vendorService.GetVendorByIdAsync(id);
            if (vendor == null)
                return NotFound();

            var associatedCustomers = await _customerService.GetAllCustomersAsync(vendorId: vendor.Id);
            foreach (var customer in associatedCustomers)
            {
                customer.VendorId = 0;
                await _customerService.UpdateCustomerAsync(customer);
            }

            await _vendorService.DeleteVendorAsync(vendor);
            return NoContent();
        }

        #endregion

        #region Vendor Notes

        [HttpGet("{vendorId}/notes")]
        [CheckPermission(StandardPermission.Customers.VENDORS_VIEW)]
        public async Task<IActionResult> VendorNotesSelect(int vendorId, VendorNoteSearchModel searchModel)
        {
            var vendor = await _vendorService.GetVendorByIdAsync(vendorId);
            if (vendor == null)
                return NotFound();

            var model = await _vendorModelFactory.PrepareVendorNoteListModelAsync(searchModel, vendor);
            return Ok(model);
        }

        [HttpPost("{vendorId}/notes")]
        [CheckPermission(StandardPermission.Customers.VENDORS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> VendorNoteAdd(int vendorId, string message)
        {
            if (string.IsNullOrEmpty(message))
                return BadRequest("Message cannot be empty");

            var vendor = await _vendorService.GetVendorByIdAsync(vendorId);
            if (vendor == null)
                return NotFound();

            var note = new VendorNote { Note = message, CreatedOnUtc = DateTime.UtcNow, VendorId = vendor.Id };
            await _vendorService.InsertVendorNoteAsync(note);

            return CreatedAtAction(nameof(VendorNotesSelect), new { vendorId = vendorId }, note);
        }

        [HttpDelete("{vendorId}/notes/{id}")]
        [CheckPermission(StandardPermission.Customers.VENDORS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> VendorNoteDelete(int vendorId, int id)
        {
            var vendorNote = await _vendorService.GetVendorNoteByIdAsync(id);
            if (vendorNote == null || vendorNote.VendorId != vendorId)
                return NotFound();

            await _vendorService.DeleteVendorNoteAsync(vendorNote);
            return NoContent();
        }

        #endregion
    }
}
