using Domain.Entity;
using Domain.Rebositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AuthenticationRepository(
        ApplicationDBContext _applicationDBContext
        ) : IAuthenticationRepository
{
    /// <summary>
    /// Get The User Information From Data Base To Compare With Request Data
    /// </summary>
    /// <param name="user"></param>
    /// <returns>User Information</returns>
    public async Task<User> Login(User user)
    {
        var userDataBase = await _applicationDBContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
        return userDataBase!;
    }

    /// <summary>
    /// Save User Information In Data Base
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task Register(User user)
    {
        await _applicationDBContext.Users.AddAsync(user);
    }
}
