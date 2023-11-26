using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Abstraction.IServices;

public interface IUserService
{
    public Task<IEnumerable<APIResponse<UserResponse>>> GetUsers();
    public Task<APIResponse<UserResponse>> AddUser(UserRequest model);
}
