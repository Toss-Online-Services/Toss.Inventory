using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toss.Inventory.Domain.Entities;
public sealed class ProductComponent : Entity
{
    public ProductComponent()
    {

    }
    public Product Component { get; private set; }
    public decimal Quantity { get; private set; }

    public ProductComponent(Product component, decimal quantity)
    {
        Component = component;
        Quantity = quantity;
    }
}
