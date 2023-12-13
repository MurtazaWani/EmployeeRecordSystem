using EmployeeRecordSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace EmployeeRecordSystem.Application.RRModels;

public class EmployeeRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Salary { get; set; }
    public IFormFile File { get; set; } = null!;
}

public class EmployeeResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Salary { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public UserStatus UserStatus { get; set; }
    public Guid CreatedBy { get; set; } 
    public DateTimeOffset CreatedOn { get; set; }
    public string FilePath { get; set; } = string.Empty;

}

//public class UpdateEmployeeRequest : EmployeeRequest
//{
//    public new Guid Id { get; set; } // hiding EmployeeRequest member
//}

public class UpdateEmployeeRequest : EmployeeRequest
{

}
