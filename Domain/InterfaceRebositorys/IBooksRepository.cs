using Domain.Entity;

namespace Domain.InterfaceRebositorys;

public interface IBooksRepository
{
    Task Create(Book book);
    void Update(Book book);
    void Delete(Book book);
    Task<List<Book>> GetAll();
    Task<Book?> GetById(int id);
}
