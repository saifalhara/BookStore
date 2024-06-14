using Application.Hangfire;
using AutoMapper;
using Domain.Abstractions;
using Domain.Dtos.UserDtos.Requests;
using Domain.Dtos.UserDtos.Responses;
using Domain.Entity;
using Domain.InterfaceRebositorys.UnitOfWork;
using Domain.InterfaceServices;
using Infrastructure.Errors.AuthenticationError;
using Infrastructure.TokenServices;

namespace Infrastructure.Services;

public class AuthenticatioService(
        IUnitOfWork _unitOfWork,
        IJwtProvider _jwtProvider,
        IMapper _mapper , 
        IHangfireServices _hangfireServices
    ) : IAuthenticatioService
{

    /// <summary>
    /// Login User 
    /// </summary>
    /// <param name="loginDto"></param>
    /// <returns>User Infirmation With Token</returns>
    public async Task<Result> Login(LoginDto loginDto)
    {
        var userLogin = _mapper.Map<LoginDto, User>(loginDto);
        userLogin.Email = loginDto.Email.Trim().ToLower();
        var user = await _unitOfWork._AuthenticationRepository.Login(userLogin);
        if (user == null)
        {
            return AuthenticationError.UserNotFound;
        }
        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
        {
            return AuthenticationError.Invalidcredentials;
        }
        var token = _jwtProvider.GenrateToken(user);
        var response = new AuthenticationResponse(
            user.Id,
            user.Email,
            user.UserName,
            token
            );

        _hangfireServices.StartTimer(user.Id);
        return Result.Success(response);
    }

    /// <summary>
    /// Register User 
    /// </summary>
    /// <param name="registerDto"></param>
    /// <returns>Return Result Message</returns>
    public async Task<Result> Register(UserDto registerDto)
    {
        var user = _mapper.Map<UserDto, User>(registerDto);
        user.Email = registerDto.Email.Trim().ToLower();
        var existEmail = await _unitOfWork._GenericUserRepository.GetByExpression((u => u.Email == user.Email));
        if (existEmail is not null)
        {
            return AuthenticationError.AlreadyExist;
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        await _unitOfWork._AuthenticationRepository.Register(user);
        if (_unitOfWork.SaveChanges() > 0)
        {
            return Result.Success();
        }
        else
        {
            return AuthenticationError.ErrorInRegister;
        }
    }
}
