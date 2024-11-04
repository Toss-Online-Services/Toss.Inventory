using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

public partial record CustomerModel
{
    #region Nested classes

    public partial record CustomerAttributeValueModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }

    #endregion
}
