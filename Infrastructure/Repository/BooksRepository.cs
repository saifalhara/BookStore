using Domain.Entity;
using Domain.InterfaceRebositorys;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class BooksRepository(
        ApplicationDBContext _applicationDBContext
        ) : IBooksRepository
{
    /// <summary>
    /// Add Category To Book
    /// </summary>
    /// <param name="category"></param>
    public async void AddCateorys(List<BookCategorys> bookCategorys)
    {
        await _applicationDBContext.BookCatigories.AddRangeAsync(bookCategorys);
    }

    /// <summary>
    /// Delete Category To Book
    /// </summary>
    /// <param name="category"></param>
    public void DeleteCategory(BookCategorys bookCategorys)
    {
        _applicationDBContext.BookCatigories.Update(bookCategorys);
    }
}
