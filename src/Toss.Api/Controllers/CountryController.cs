//using Microsoft.AspNetCore.Mvc;
//using Nop.Web.Framework.Mvc.Filters;
//using Toss.Api.Factories;

//namespace Nop.Web.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CountryController : ControllerBase
//    {
//        #region Fields

//        private readonly ICountryModelFactory _countryModelFactory;

//        #endregion

//        #region Ctor

//        public CountryController(ICountryModelFactory countryModelFactory)
//        {
//            _countryModelFactory = countryModelFactory;
//        }

//        #endregion

//        #region States / Provinces

//        // Allow access even when navigation is not allowed
//        [CheckAccessPublicStore(ignore: true)]
//        // Ignore SEO friendly URLs checks
//        [CheckLanguageSeoCode(ignore: true)]
//        [HttpGet("GetStatesByCountryId/{countryId}")]
//        public async Task<IActionResult> GetStatesByCountryId(int countryId, bool addSelectStateItem)
//        {
//            var model = await _countryModelFactory.GetStatesByCountryIdAsync(countryId, addSelectStateItem);

//            return Ok(model);
//        }

//        #endregion
//    }
//}
