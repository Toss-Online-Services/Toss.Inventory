using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Lifecycle : Entity
{
    public DateTime? ManufactureDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string BatchNumber { get; set; }
    public string SerialNumber { get; set; }
}

