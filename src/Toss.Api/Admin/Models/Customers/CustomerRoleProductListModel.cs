using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Catalog;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer role product list model
/// </summary>
public partial record CustomerRoleProductListModel : BasePagedListModel<ProductModel>
{
}