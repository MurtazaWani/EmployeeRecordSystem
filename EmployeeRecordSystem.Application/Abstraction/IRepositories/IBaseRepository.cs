using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Abstraction.IRepositories;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(int pageNo, int pageSize);
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(Guid id);
    Task<T> DeleteAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> expression);
    Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression);
    Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);
    Task<int> DeleteRangeAsync(List<Guid> ids);
    Task<int> DeleteRangeAsync(List<T> entityList);
    Task<int> AddRangeAsync(List<T> entity);
}
