using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Domain.Entities;

public class Employee : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public int Salary { get; set; } = 0;

    [ForeignKey(nameof(Id))]
    public User User { get; set; }
}
