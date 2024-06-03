using Microsoft.Extensions.Logging;

namespace Application.Infrastructure.Extensions;

public static partial class ApiTrace
{
    [LoggerMessage(EventId = 1, EventName = "ProductCreated", Level = LogLevel.Trace, Message = "Product with Id: {ProductId} has been successfully Created")]
    public static partial void LogProductCreated(ILogger logger, int productId);
}
