using AutoMapper;
using Domain.Abstractions;
using Domain.Dtos.Sheard;
using Domain.Dtos.UserDto.Responses;
using Domain.Dtos.UserDtos.Requests;
using Domain.Entity;
using Domain.Entity.Relations;
using Domain.InterfaceRebositorys.UnitOfWork;
using Domain.InterfaceServices;
using Infrastructure.Errors.UsersError;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class UserServices(
        IMapper _mapper,
        IUnitOfWork _unitOfWork , 
        IHttpContextAccessor _httpContextAccessor
    ) : IUserServices
{

    /// <summary>
    /// Create New User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    public async Task<Result> Create(UserDto userDto)
    {
        var user = _mapper.Map<UserDto, User>(userDto);
        user.CreateDate = DateTime.Now;
        user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        await _unitOfWork._GenericUserRepository.Create(user);
        return await _unitOfWork.SaveChangesAsync() > 0 ? Result.Success() : Result.Failure();
    }

    /// <summary>
    /// Delete User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    public async Task<Result> Delete(Delete delete)
    {
        var user = await GetById(delete.Id);
        if (user.IsSuccess is false)
        {
            return user.Error ?? UsersError.UserNotFound;
        }
        var deleteUser = (User?)user.Response;
        deleteUser!.IsDeleted = true;
        _unitOfWork._GenericUserRepository.Delete(deleteUser);
        return (await _unitOfWork.SaveChangesAsync() > 0) ? Result.Success() : Result.Failure();
    }

    /// <summary>
    /// Get All User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    public async Task<Result> Get()
    {
        var user = await _unitOfWork._GenericUserRepository.Get();
        var responseUser = _mapper.Map<List<User>, List<UserResponseDto>>(user);
        return (user is null) ? UsersError.NoUsers : Result.Success(responseUser);
    }

    /// <summary>
    /// Get User By Id
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    public async Task<Result> GetById(int id)
    {
        var user = await _unitOfWork._GenericUserRepository.GetByExpression((u => u.Id == id));
        var responseUser = _mapper.Map<User, UserResponseDto>(user);
        return (user is null) ? UsersError.NoUsers : Result.Success(responseUser);
    }

    /// <summary>
    /// Update User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    public async Task<Result> Update(int id, UserDto userDto)
    {
        var result = await GetById(id);
        var getUser = (UserResponseDto?)result.Response ?? new();
        if (getUser.Id == 0)
        {
            return UsersError.NoUsers;
        }
        var user = new User()
        {
            Id = id,
            EditDate = DateTime.Now,
            CreateDate = getUser.CreatedDate,
            Password = getUser.Password,
            Email = userDto.Email,
            UserName = userDto.UserName,
        };
        _unitOfWork._GenericUserRepository.Update(user);
        return (await _unitOfWork.SaveChangesAsync() > 0) ? Result.Success() : Result.Failure();
    }

    /// <summary>
    /// Change The Date Of The User When Join The Application
    /// </summary>
    /// <returns></returns>
    public async Task<Result> Join()
    {
        int id = Convert.ToInt32(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(u => u.Type == "User_Id")?.Value);
        var result = await GetById(id);
        var userResponse = (UserResponseDto?)result.Response ?? new();
        userResponse.ReadTo = DateTime.Now;
        var user = _mapper.Map<UserResponseDto, User>(userResponse);
        _unitOfWork._GenericUserRepository.Update(user);
        return (await _unitOfWork.SaveChangesAsync() > 0) ? Result.Success() : Result.Failure();
    }

    /// <summary>
    /// Change The Date Of The User When Leave The Application
    /// </summary>
    /// <returns></returns>
    public async Task<Result> Leave()
    {
        int id = Convert.ToInt32(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(u => u.Type == "User_Id")?.Value);
        var result = await GetById(id);
        var userResponse = (UserResponseDto?)result.Response ?? new();
        userResponse.ReadFrom = DateTime.Now;
        var user = _mapper.Map<UserResponseDto, User>(userResponse);
        _unitOfWork._GenericUserRepository.Update(user);
        return (await _unitOfWork.SaveChangesAsync() > 0) ? Result.Success() : Result.Failure();
    }

    public async Task<Result> SaveBook(int userId , int bookId)
    {
        _unitOfWork._UsersRepository.SaveBook(new UserBooks { UserId = userId, BookId = bookId });
        return (await _unitOfWork.SaveChangesAsync() > 0) ? Result.Success() : Result.Failure();
    }
}
