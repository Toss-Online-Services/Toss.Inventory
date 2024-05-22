using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Lifecycle : ValueObject
{
    public DateTime? ManufactureDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string BatchNumber { get; set; }
    public string SerialNumber { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ManufactureDate;
        yield return ExpirationDate;
        yield return BatchNumber;
        yield return SerialNumber;

    }
}

