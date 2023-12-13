using EmployeeRecordSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Domain.Entities;

public class AppFiles : BaseModel
{
    public string FilePath { get; set; } = null!;
    public Guid EntityId { get; set; }
    public AppModule Module { get; set; }
}
