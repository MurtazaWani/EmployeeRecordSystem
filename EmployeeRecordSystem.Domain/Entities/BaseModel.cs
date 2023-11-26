using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Domain.Entities;

public class BaseModel
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
}
