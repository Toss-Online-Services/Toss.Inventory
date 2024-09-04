namespace Domain.Exceptions;

/// <summary>
/// Exception type for domain exceptions
/// </summary>
public class InventoryDomainException : Exception
{
    public InventoryDomainException()
    { }

    public InventoryDomainException(string message)
        : base(message)
    { }

    public InventoryDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
