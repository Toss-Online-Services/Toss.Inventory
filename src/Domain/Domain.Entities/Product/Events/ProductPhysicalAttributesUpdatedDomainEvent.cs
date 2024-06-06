using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product.Events;
public record ProductPhysicalAttributesUpdatedDomainEvent(string ProductId, PhysicalAttributes PhysicalAttributes) : BaseEvent;
