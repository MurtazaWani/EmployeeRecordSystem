using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Application.Shared;

namespace EmployeeRecordSystem.Application.Abstraction.IServices;

public interface IEmployeeService
{
    Task<APIResponse<IEnumerable<EmployeeResponse>>> GetEmployees();
    Task<APIResponse<EmployeeResponse>> AddEmployee(EmployeeRequest model);
}
