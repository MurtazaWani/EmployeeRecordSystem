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
    public Task<APIResponse<IEnumerable<UserResponse>>> GetUsers();
    public Task<APIResponse<UserResponse>> Signup(UserRequest model);
    Task<APIResponse<LoginResponse>> Login(LoginRequest model);
}
