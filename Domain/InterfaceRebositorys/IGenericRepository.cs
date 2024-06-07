using System.Linq.Expressions;

namespace Domain.InterfaceRebositorys;

public interface IGenericRepository<T> where T : class
{
    Task Create(T entity);
    void Delete(T entity);
    Task<List<T>> Get();
    void Update(T entity);
    Task<T> GetByExpression(Expression<Func<T, bool>> expression);
}
