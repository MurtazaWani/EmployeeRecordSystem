using EmployeeRecordSystem.Application.Abstraction.IJWT;
using EmployeeRecordSystem.Infrastructure.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Infrastructure;

public static class AssemblyReference
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IJWTProvider>(new JWTProvider(config));
        return services;
    }
}
