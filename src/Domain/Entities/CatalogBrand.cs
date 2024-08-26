using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class CatalogBrand
{
    public int Id { get; private set; }

    [Required]
    public string Brand { get; private set; }
}
