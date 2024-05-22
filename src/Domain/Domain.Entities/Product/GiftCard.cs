using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class GiftCard : Entity
{
    public bool IsGiftCard { get; set; }
    public int GiftCardTypeId { get; set; }
    public decimal? OverriddenGiftCardAmount { get; set; }
}

