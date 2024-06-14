using Domain.Entity.Relations;
using Domain.InterfaceRebositorys;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class UsersRepository(ApplicationDBContext _applicationDBContext) : IUsersRepositroty
{
    public void SaveBook(UserBooks book)
    {
        _applicationDBContext.UserBooks.Add(book);
    }
}
