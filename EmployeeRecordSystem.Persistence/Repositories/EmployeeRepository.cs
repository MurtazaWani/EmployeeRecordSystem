using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Persistence.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(EmployeeRecordSystemDbContext context) : base(context)
    {

    }
}
