using EmployeeRecordSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.RRModels;

public class AppFileResponse
{
    public Guid Id { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public AppModule Module { get; set; }
    public Guid EntityId { get; set; }
}
