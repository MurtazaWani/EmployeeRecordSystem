using EmployeeRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Abstraction.IJWT;

public interface IJWTProvider
{
    public string GenerateToken(User user);
}
