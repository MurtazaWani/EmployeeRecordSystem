using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService service;
    public UsersController(IUserService service)
    {
        this.service = service;
    }

    [HttpGet]
    public Task<IEnumerable<APIResponse<EmployeeResponse>>> GetAll()
    {
        return null;
    }

    [HttpPost]
    public Task<APIResponse<EmployeeResponse>> Add()
    {
        return null;
    }

}
