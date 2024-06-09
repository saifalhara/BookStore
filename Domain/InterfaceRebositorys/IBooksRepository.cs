using Domain.Dtos.BookDto.Requests;
using Domain.Entity;

namespace Domain.InterfaceRebositorys;

public interface IBooksRepository
{
    void AddCateorys(List<BookCategorys> bookCategorys);
    void DeleteCategory(BookCategorys bookCategorys);
}
