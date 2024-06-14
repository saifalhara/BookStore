using Domain.Entity.Relations;
using Domain.InterfaceRebositorys;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository;

public class GenericRepository<T>(
        ApplicationDBContext _applicationDBContext
        ) : IGenericRepository<T> where T : class
{

    /// <summary>
    /// Create a new Record In DataBase
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>No Return</returns>
    public async Task Create(T entity)
    {
        await _applicationDBContext.Set<T>().AddAsync(entity);
    }

    /// <summary>
    /// Delete Record From Data Base
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(T entity)
    {
        _applicationDBContext.Set<T>().Update(entity);
    }

    /// <summary>
    /// Get All Record From Data Base
    /// </summary>
    /// <returns>Return All Record</returns>
    public async Task<List<T>> Get()
    {
        return await _applicationDBContext.Set<T>().ToListAsync();
    }

    /// <summary>
    /// Get Record Based On Expression
    /// </summary>
    /// <param name="expression"></param>
    /// <returns>Return Record</returns>
    public async Task<T> GetByExpression(Expression<Func<T , bool>> expression)
    {
        IQueryable<T> data = _applicationDBContext!.Set<T>();
        return await data.AsNoTracking().FirstOrDefaultAsync(expression!);
    }

    /// <summary>
    /// Updata Record In Data Base
    /// </summary>
    /// <param name="entity"></param>
    public void Update(T entity)
    {
        _applicationDBContext.Set<T>().Update(entity);
    }
}
