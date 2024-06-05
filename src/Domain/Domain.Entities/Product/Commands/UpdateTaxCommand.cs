using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product.Commands;
public record UpdateTaxCommand() : ICommand<bool>
{
    public bool IsTaxExempt { get; init; }
    public int TaxCategoryId { get; init; }

}
