using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class CatalogType
{
    public int Id { get; private set; }

    [Required]
    public string Type { get; private set; }
}
