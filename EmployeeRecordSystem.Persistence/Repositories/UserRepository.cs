using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly EmployeeRecordSystemDbContext context;
    public UserRepository(EmployeeRecordSystemDbContext context) : base(context)
    {
        this.context = context;
    }

    //public async Task<IEnumerable<User>> GetAllAsync()
    //{
    //    return await Task.Run(() => context.Set<User>());
    //}

    //public async Task<int> AddAsync(User model)
    //{
    //    await context.Set<User>().AddAsync(model);
    //    return await context.SaveChangesAsync();
    //}
}
