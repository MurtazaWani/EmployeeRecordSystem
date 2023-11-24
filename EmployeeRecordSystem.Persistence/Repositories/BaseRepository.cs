using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel, new()
{
    private readonly EmployeeRecordSystemDbContext context;

    public BaseRepository(EmployeeRecordSystemDbContext context)
    {
        this.context = context;
    }
    public async Task<int> AddAsync(T model)
    {
        await context.Set<T>().AddAsync(model);
        return await context.SaveChangesAsync();
    }

    public async Task<int> AddRangeAsync(List<T> models)
    {
        await context.Set<T>().AddRangeAsync(models);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var model = new T() { Id = id };
        await Task.Run(() => context.Set<T>().Remove(model));
        return await context.SaveChangesAsync();
    }

    public async Task<T> DeleteAsync(T entity)
    {
        await Task.Run(() => context.Remove(entity));
        var rowEffect = await context.SaveChangesAsync();
        if (rowEffect > 0)
        {
            return entity;
        }
        else return null;
    }

    public async Task<int> DeleteRangeAsync(List<Guid> ids)
    {
        List<T> models = new List<T>();
        foreach(var id in ids)
        {
            //var model = new T() { Id = id };
            models.Add(new T() { Id = id });
        }
        await Task.Run(() => context.Set<T>().RemoveRange(models));
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteRangeAsync(List<T> entityList)
    {
        await Task.Run(() => context.Set<T>().RemoveRange(entityList));
        return await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> expression)
    {
        return await Task.Run(() => context.Set<T>().Where(expression));
    }

    public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return await context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Task.Run(() => context.Set<T>());
    }

    public async Task<IEnumerable<T>> GetAllAsync(int pageNo, int pageSize)
    {
        return await context.Set<T>()
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression)
    {
        return await context.Set<T>().AnyAsync(expression);
    }

    public async Task<int> UpdateAsync(T entity)
    {
        await Task.Run(() => context.Set<T>().Update(entity));
        return await context.SaveChangesAsync();
    }
}

