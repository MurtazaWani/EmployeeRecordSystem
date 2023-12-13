using AutoMapper;
using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Domain.Enums;
using System.Net;

namespace EmployeeRecordSystem.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository repository;
    private readonly IMapper mapper;
    private readonly IFileService fileService;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper, IFileService fileService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.fileService = fileService;
    }

    public async Task<APIResponse<EmployeeResponse>> AddEmployee(EmployeeRequest model)
    {
        var employee = mapper.Map<Employee>(model);
        var employeeResponse = await fileService.UploadFileAync(AppModule.Employee, model.Id, model.File);
        var res = await repository.AddAsync(employee);
        if( res >  0 )
        {
            return APIResponse<EmployeeResponse>.SuccessResponse(HttpStatusCode.Created, mapper.Map<EmployeeResponse>(employee));
        }
        return APIResponse<EmployeeResponse>.ErrorResponse(HttpStatusCode.BadRequest);
    }

    public async Task<APIResponse<IEnumerable<EmployeeResponse>>> GetEmployees()
    {
        var employees = await repository.GetCompactEmployees();
        if(employees.Any())
        {            
            return APIResponse<IEnumerable<EmployeeResponse>>.SuccessResponse(HttpStatusCode.OK, employees);
        }
        return APIResponse<IEnumerable<EmployeeResponse>>.ErrorResponse(HttpStatusCode.NoContent);
    }
}
