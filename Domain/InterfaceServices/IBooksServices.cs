using Domain.Abstractions;
using Domain.Dtos.BookDto.Requests;
using Domain.Dtos.Sheard;
using Domain.Entity;

namespace Domain.InterfaceServices;

public interface IBooksServices
{
    /// <summary>
    /// Create New Book In Date Base
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns>Return The Result If Data Saved Or No</returns>
    Task<Result> Create(BookDto book);

    /// <summary>
    /// Updat Book By Book Dto
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns>Result About Status Of Save User</returns>
    Task<Result> Update(int Id, BookDto book);

    /// <summary>
    /// Delete Book 
    /// </summary>
    /// <param name="bookDto"></param> 
    /// <returns>Return The Result About Status If Data Deleted Or Not</returns>
    Task<Result> Delete(Delete book);

    /// <summary>
    /// Get All Book From Data Base
    /// </summary>
    /// <returns></returns>
    Task<Result> GetAll();

    /// <summary>
    /// Get Book By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return The Book By Id</returns>
    Task<Result> GetById(int id);

    /// <summary>
    /// Add Category To Book
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<Result> AddCateorys(int Id , List<Category> categories);

    /// <summary>
    /// Delete Category To Book
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<Result> DeleteCategory(int Id, Category category);
}
