using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

public partial record CustomerModel
{   
    #region Nested classes

    public partial record CustomerAttributeModel : BaseNopEntityModel
    {
        public CustomerAttributeModel()
        {
            Values = new List<CustomerAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<CustomerAttributeValueModel> Values { get; set; }
    }

    #endregion
}
