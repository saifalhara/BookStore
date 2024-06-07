using Domain.Entity;
using Domain.InterfaceRebositorys;
using Domain.InterfaceRebositorys.UnitOfWork;
using Domain.Rebositorys;
using Infrastructure.Data;

namespace Infrastructure.Repository.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;
    public IAuthenticationRepository _AuthenticationRepository { get; private set; }

    public IBooksRepository _BooksRepository {  get; private set; }
    public IGenericRepository<Book> _GenericBookRepository {  get; private set; }
    public IGenericRepository<User> _GenericUserRepository {  get; private set; }

    public UnitOfWork(ApplicationDBContext context,
                      IAuthenticationRepository authenticationRepository,
                      IBooksRepository booksRepository ,
                      IGenericRepository<Book> GenericRepository ,
                      IGenericRepository<User> GenericUserRepository )
    {
        _context = context;
        _AuthenticationRepository = authenticationRepository;
        _BooksRepository = booksRepository;
        _GenericBookRepository = GenericRepository;
        _GenericUserRepository = GenericUserRepository;
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
