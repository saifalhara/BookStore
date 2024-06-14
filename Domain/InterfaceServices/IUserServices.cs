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

    /// <summary>
    /// Book Saved By User
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="bookId"></param>
    /// <returns>Return Result</returns>
    
    Task<Result> SaveBook(int userId, int bookId);

    /// <summary>
    /// Change The Date Of The User When Join The Application
    /// </summary>
    /// <returns></returns>
    Task<Result> Join();

    /// <summary>
    /// Change The Date Of The User When Leave The Application
    /// </summary>
    /// <returns></returns>
    Task<Result> Leave();

}
