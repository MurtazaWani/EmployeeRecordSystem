using EmployeeRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Abstraction.IRepositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
}
