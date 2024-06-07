namespace Domain.Abstractions;

public class Error
{
    public string? Code { get; private set; } = string.Empty;
    public string? Message { get; private set; } = string.Empty;
    public Error(string code, string? message = null)
    {
        Code = code;
        Message = message;
    }

    public static readonly Error None = new(string.Empty);
    public static implicit operator Result(Error error) => Result.Failure(error);
}
