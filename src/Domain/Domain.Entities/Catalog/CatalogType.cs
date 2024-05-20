using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Catalog;

public class CatalogType
{
    public int Id { get; set; }

    [Required]
    public string Type { get; set; }
}
