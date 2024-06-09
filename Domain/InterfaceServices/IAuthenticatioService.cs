using Domain.Abstractions;
using Domain.Dtos.UserDtos.Requests;

namespace Domain.InterfaceServices;

public interface IAuthenticatioService
{
    Task<Result> Login(LoginDto loginDto);
    Task<Result> Register(UserDto registerDto);
}
