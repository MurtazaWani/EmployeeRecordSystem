using AutoMapper;
using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;
using EmployeeRecordSystem.Application.Utils;
using EmployeeRecordSystem.Domain.Entities;
using System.Net;

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

    public async Task<APIResponse<UserResponse>> Signup(UserRequest model)
    {
        var user = mapper.Map<User>(model);
        if(await repository.IsExistsAsync(u => u.Username  == model.Username))
        {
            return APIResponse<UserResponse>.ErrorResponse(HttpStatusCode.BadRequest ,"Username already exists");
        }
        //var exists = await repository.IsExistsAsync(x => x.Username == user.Username);
        user.Salt = AppEncryption.GenerateSalt();
        user.Password = AppEncryption.CreatePasswordHash(user.Password, user.Salt);
        var res = await repository.AddAsync(user);
        if (res > 0)
        {
            // without calling method
            //return new APIResponse<UserResponse>(HttpStatusCode.OK, true, "success", userResponse);

            // with calling method
            return APIResponse<UserResponse>.SuccessResponse(HttpStatusCode.Created, mapper.Map<UserResponse>(user));
        }
        else return APIResponse<UserResponse>.ErrorResponse(HttpStatusCode.BadRequest);
    }

    public async Task<APIResponse<IEnumerable<UserResponse>>> GetUsers()
    {
        var users = await repository.GetAllAsync();
        var usersResponse = users.Select(x => new UserResponse
        {
            Id = x.Id,
            Username = x.Username,
            Email = x.Email,
            Phone = x.Phone,
        });

        if(users.Any())
        {
            return APIResponse<IEnumerable<UserResponse>>.SuccessResponse(HttpStatusCode.OK, usersResponse);
        }
        else return APIResponse<IEnumerable<UserResponse>>.ErrorResponse(HttpStatusCode.InternalServerError, "something went wrong");
    }
}
