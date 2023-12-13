using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Persistence.Data;

namespace EmployeeRecordSystem.Persistence.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private readonly EmployeeRecordSystemDbContext context;
    public EmployeeRepository(EmployeeRecordSystemDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<EmployeeResponse>> GetCompactEmployees()
    {
        string query = $@"select U.Id, U.Username, U.Email, U.Phone, U.UserStatus,
                                 E.[Name], E.Salary, E.CreatedBy, E.CreatedOn, F.FilePath
                                 from Users as U 
                                 inner join Employees as E 
                                 on U.Id = E.Id
                                 left join AppFiles as F 
                                 on F.EntityId = U.Id";
                                 
        return await QueryAsync<EmployeeResponse>(query);
    }
    
}
