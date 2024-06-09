using Domain.Abstractions;

namespace Infrastructure.Errors.UsersError;

public class UsersError
{
    public readonly static Error UserNotFound = new("UserNotFound", "User Not Found");
    public readonly static Error NoUsers = new("NoUser", "No User"); 
}
