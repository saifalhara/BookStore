using Domain.Abstractions;

namespace Infrastructure.Errors.AuthenticationError;

public class AuthenticationError
{
    public static Error Invalidcredentials = new("Invlidcredentials", "Email Or Password Wrong!");
    public static Error UserNotFound = new("UserNotFound", "User Not Found!");
    public static Error AlreadyExist = new("UserALreadyExist", "User ALready Exist!");
    public static Error ErrorInRegister = new("Error To Register Please Try Again", "Please Try Again");
}
