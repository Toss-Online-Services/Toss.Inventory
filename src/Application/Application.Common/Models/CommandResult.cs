namespace Application.Common.Models;
public class CommandResult<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public CommandResult(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static CommandResult<T> SuccessResult(T data, string message = "")
    {
        return new CommandResult<T>(true, message, data);
    }

    public static CommandResult<T> FailureResult(string message)
    {
        return new CommandResult<T>(false, message, default(T));
    }
}

