using Domain.Abstractions;
using Domain.Dtos.Sheard;
using Domain.Dtos.UserDtos.Requests;

namespace Domain.InterfaceServices;

public interface IUserServices
{
    /// <summary>
    /// Create New User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    Task<Result> Create(UserDto user);


    /// <summary>
    /// Update User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    Task<Result> Update(int id , UserDto user);


    /// <summary>
    /// Delete User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    Task<Result> Delete(Delete user);

    /// <summary>
    /// Get All User
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    Task<Result> Get();

    /// <summary>
    /// Get User By Id
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns>Return Result</returns>
    Task<Result> GetById(int id);

}
