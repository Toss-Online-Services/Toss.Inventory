using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Tax:Entity
{
    public bool IsTaxExempt { get; set; }
    public int TaxCategoryId { get; set; }
}

