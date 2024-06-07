using Domain.Entity;
using Domain.Rebositorys;

namespace Domain.InterfaceRebositorys.UnitOfWork;

public interface IUnitOfWork : IDisposable
{

    public IAuthenticationRepository _AuthenticationRepository { get; }
    public IBooksRepository _BooksRepository { get; }
    public IGenericRepository<Book> _GenericBookRepository { get; }
    public IGenericRepository<User> _GenericUserRepository { get; }

    public int SaveChanges();
    Task<int> SaveChangesAsync();
}
