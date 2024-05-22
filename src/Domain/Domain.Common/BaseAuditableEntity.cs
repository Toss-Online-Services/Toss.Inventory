namespace Domain.Infrastructure;

public abstract class BaseAuditableEntity : Entity
{
    public DateTimeOffset CreatedOnUtc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset UpdatedOnUtc { get; set; }

    public string? LastModifiedBy { get; set; }
}
