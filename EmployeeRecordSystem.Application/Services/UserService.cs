using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository repository;

    public UserService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<APIResponse<EmployeeResponse>>> GetUsers()
    {
        return null;
    }
}
