using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Catalog;

public class CatalogBrand
{
    public int Id { get; set; }

    [Required]
    public string Brand { get; set; }
}
