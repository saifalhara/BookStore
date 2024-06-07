using Domain.Entity;

namespace Infrastructure.TokenServices;

public interface IJwtProvider
{
    string GenrateToken(User user);
}
