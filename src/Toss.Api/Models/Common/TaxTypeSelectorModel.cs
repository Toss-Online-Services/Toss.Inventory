using Nop.Core.Domain.Tax;
using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Common;

public partial record TaxTypeSelectorModel : BaseNopModel
{
    public TaxDisplayType CurrentTaxType { get; set; }
}