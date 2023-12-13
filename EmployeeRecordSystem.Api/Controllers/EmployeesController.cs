using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService service;

    public EmployeesController(IEmployeeService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<APIResponse<IEnumerable<EmployeeResponse>>> GetAll()
    {
        return await service.GetEmployees();
    }

    [HttpPost]    
    public async Task<APIResponse<EmployeeResponse>> Add([FromForm] EmployeeRequest model)
    {
        return await service.AddEmployee(model);
    }
}
