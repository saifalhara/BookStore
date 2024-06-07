using Domain.Entity;

namespace Domain.Rebositorys;

public interface IAuthenticationRepository
{
    Task Register(User user);
    Task<User> Login(User user);
}
