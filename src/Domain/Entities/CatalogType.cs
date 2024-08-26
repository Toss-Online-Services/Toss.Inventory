using System.ComponentModel.DataAnnotations;

namespace Toss.Inventory.Domain.Entities;

public class CatalogType
{
    public int Id { get; private set; }

    [Required]
    public string Type { get; private set; }
}
