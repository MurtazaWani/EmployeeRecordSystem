using AutoMapper;
using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;
using EmployeeRecordSystem.Domain.Entities;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<APIResponse<UserResponse>> AddUser(UserRequest model)
    {
        var user = mapper.Map<User>(model);
        var res = await repository.AddAsync(user);
        if (res > 0)
        {
            var userResponse = mapper.Map<UserResponse>(user);

            // without calling method
            //return new APIResponse<UserResponse>(HttpStatusCode.OK, true, "success", userResponse);

            // with calling method
            return APIResponse<UserResponse>.SuccessResponse(HttpStatusCode.Created, userResponse);
        }
        else return APIResponse<UserResponse>.ErrorResponse(HttpStatusCode.BadRequest, null);
    }

    public async Task<IEnumerable<APIResponse<UserResponse>>> GetUsers()
    {
        var users = await repository.GetAllAsync();
        if(users != null)
        {
            return users.Select(x => APIResponse<UserResponse>.SuccessResponse(HttpStatusCode.OK, new UserResponse
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                Phone = x.Phone,
            }));
        }
        else return null;
    }

}
