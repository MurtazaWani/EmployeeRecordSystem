using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRecordSystem.Domain.Enums;

namespace EmployeeRecordSystem.Domain.Entities;

public class User : BaseModel
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserStatus UserStatus { get; set; }

    #region Nav
    public Employee Employee { get; set; }
    #endregion
}
