using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure;
/// <summary>
/// Represents an entity which supports discounts
/// </summary>
public partial interface IDiscountSupported<T> where T : IDiscountMapping
{
    int Id { get; set; }
}
