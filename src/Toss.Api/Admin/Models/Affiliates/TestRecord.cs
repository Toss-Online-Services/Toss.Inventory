using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Toss.Api.Admin.Models.Common;

namespace Toss.Api.Admin.Models.Affiliates
{
    public record TestRecord : BaseNopEntityModel
    {

        [NopResourceDisplayName("Admin.Affiliates.Fields.URL")]
        public string Url { get; set; }

        [NopResourceDisplayName("Admin.Affiliates.Fields.AdminComment")]
        public string AdminComment { get; set; }

        [NopResourceDisplayName("Admin.Affiliates.Fields.FriendlyUrlName")]
        public string FriendlyUrlName { get; set; }

        [NopResourceDisplayName("Admin.Affiliates.Fields.Active")]
        public bool Active { get; set; }

        public AddressModel Address { get; set; }

        //public AffiliatedOrderSearchModel AffiliatedOrderSearchModel { get; set; }

        //public AffiliatedCustomerSearchModel AffiliatedCustomerSearchModel { get; set; }

    }

}
