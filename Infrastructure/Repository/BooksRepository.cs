using Domain.Entity;
using Domain.InterfaceRebositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BooksRepository(
        ApplicationDBContext _applicationDBContext
        ) : IBooksRepository
{

}
