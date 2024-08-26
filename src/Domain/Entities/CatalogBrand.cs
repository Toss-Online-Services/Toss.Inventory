using System.ComponentModel.DataAnnotations;

namespace Toss.Inventory.Domain.Entities;

public class CatalogBrand
{
    public int Id { get; private set; }

    [Required]
    public string Brand { get; private set; }
}
