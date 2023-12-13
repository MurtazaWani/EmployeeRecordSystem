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
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, string webRootPath)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IUserService, UserService>();
        services.AddSingleton<IStorageService>(new StorageService(webRootPath));
        services.AddScoped<IFileService, FileService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
