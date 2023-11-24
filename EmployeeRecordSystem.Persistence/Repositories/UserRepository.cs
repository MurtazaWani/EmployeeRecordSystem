using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
}
