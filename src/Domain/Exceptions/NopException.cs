namespace Domain.Exceptions;

/// <summary>
/// Exception type for domain exceptions
/// </summary>
public class NopException : Exception
{
    public NopException()
    { }

    public NopException(string message)
        : base(message)
    { }

    public NopException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
