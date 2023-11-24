using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.RRModels;

public class EmployeeRequest
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}

public class EmployeeResponse : EmployeeRequest
{
    public Guid Id { get; set; }
}

public class UpdateEmployeeRequest : EmployeeRequest
{
    public Guid Id { get; set; }
}
