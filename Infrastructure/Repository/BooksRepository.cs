using Domain.Entity;
using Domain.InterfaceRebositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BooksRepository(
        ApplicationDBContext _applicationDBContext
        ) : IBooksRepository
{
    public async Task Create(Book book)
    {
        await _applicationDBContext.Books.AddAsync(book);
    }

    public void Delete(Book book)
    {
        book.IsDeleted = true;
        _applicationDBContext.Books.Update(book);
    }

    public async Task<List<Book>> GetAll()
    {
        return await _applicationDBContext.Books.ToListAsync();
    }

    public async Task<Book?> GetById(int id)
    {
        return await _applicationDBContext.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public void Update(Book book)
    {
        _applicationDBContext.Books.Update(book);
    }
}
