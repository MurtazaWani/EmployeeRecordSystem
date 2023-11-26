using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application;

public static class AssemblyReference
{
    public static IServiceCollection GetApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        return services;
    }
}
