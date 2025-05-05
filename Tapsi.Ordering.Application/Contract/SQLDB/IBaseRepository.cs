using System.Linq.Expressions;
using Tapsi.Ordering.Domain.Entities.SQL;
using Tapsi.Ordering.Domain.Entities.SQL;

namespace Tapsi.Ordering.Application.Contract.Database.SQLDB;

public interface IBaseRepository<T> where T : EntityBase
{
    Task<IReadOnlyList<T>> GetAllAsync();
    IReadOnlyList<T> GetAll();
    T GetById(object id);
    Task<T> GetByIdAsync(object id);
    Task<T> AddAsync(T entity);
    Task<List<T>> AddRangeAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(List<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(List<T> entities);
}