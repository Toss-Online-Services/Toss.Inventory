using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Domain.Entities.Product.Events;
public record ProductGiftCardUpdatedDomainEvent(string ProductId, GiftCard GiftCard) : BaseEvent;
