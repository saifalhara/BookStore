using AutoMapper;
using Domain.Abstractions;
using Domain.Dtos.Sheard;
using Domain.Dtos.UserDto.Responses;
using Domain.Dtos.UserDtos.Requests;
using Domain.Entity;
using Domain.InterfaceRebositorys.UnitOfWork;
using Domain.InterfaceServices;
using Infrastructure.Errors.UsersError;

namespace Infrastructure.Services;

public class UserServices(
        IMapper _mapper,
        IUnitOfWork _unitOfWork
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
    public async Task<Result> Update(int id , UserDto userDto)
    {
        var result = await GetById(id);
        var getUser = (UserResponseDto?)result.Response ?? new();
        if (getUser is null)
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
}
