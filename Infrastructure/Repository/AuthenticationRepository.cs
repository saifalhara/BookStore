using Domain.Entity;
using Domain.Rebositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AuthenticationRepository(
        ApplicationDBContext _applicationDBContext
        ) : IAuthenticationRepository
{
    public async Task<User> Login(User user)
    {
        var userDataBase = await _applicationDBContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
        return userDataBase!;
    }

    public async Task Register(User user)
    {
        await _applicationDBContext.Users.AddAsync(user);
    }
}
