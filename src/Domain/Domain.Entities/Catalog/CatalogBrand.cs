using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Catalog;

public class CatalogBrand
{
    public int Id { get; private set; }

    [Required]
    public string Brand { get; private set; }
}
