using Dapper;
using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Persistence.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace EmployeeRecordSystem.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel, new()
{
    private readonly EmployeeRecordSystemDbContext context;

    public BaseRepository(EmployeeRecordSystemDbContext context)
    {
        this.context = context;
    }

    #region async methods
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

    #endregion

    #region dapper methods

    public async Task<int> ExecuteAsync<T>(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return await context.ExecuteAsyncDapperExtension<T>(sql, param, commandType, transaction);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return await context.QueryAsyncDapperExtension<T>(sql, param, commandType, transaction);
    }

    public Task<T> FirstOrDefault<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return context.FirstOrDefaultDapperExtension<T>(sql, param, commandType, transaction);
    }

    public Task<T> SingleOrDefault<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return context.SingleOrDefaultDapperExtension<T>(sql, param, commandType, transaction);
    }

    #endregion
}

#region Dapper Method As Extension On EF Core

public static class DapperAsExtensionOnEFCore
{
    public static async Task<IEnumerable<T>> QueryAsyncDapperExtension<T>(this DbContext context, string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        try
        {
            SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.QueryAsync<T>(sql, param, transaction, null, commandType);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
        finally { context.Dispose(); }
    }

    public static async Task<int> ExecuteAsyncDapperExtension<T>(this DbContext context, string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        try
        {
            SqlConnection connection = new SqlConnection(context.Database.GetConnectionString());
            return await connection.ExecuteAsync(sql, param, transaction, null, commandType);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            context.Dispose();
        }
    }

    public static async Task<T?> SingleOrDefaultDapperExtension<T>(this DbContext context, string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        try
        {
            using(SqlConnection connection = new SqlConnection(context.Database.GetConnectionString()))
            {
                return await connection.QuerySingleOrDefaultAsync(sql, param, transaction, null, commandType);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }      
    }

    public static async Task<T?> FirstOrDefaultDapperExtension<T>(this DbContext context, string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(context.Database.GetConnectionString()))
            {
                return await connection.QueryFirstOrDefaultAsync(sql, param, transaction, null, commandType);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
#endregion
