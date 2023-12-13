using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Domain.Enums;

public enum UserStatus
{
    Active = 1,
    InActive = 2,
    Blocked = 3,
}
public enum AppModule
{
    User = 1,   
    Employee = 2,
    Department = 3,
}