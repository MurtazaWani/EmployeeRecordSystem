using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Persistence.Data;
using EmployeeRecordSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Persistence;

public static class AssemblyReference
{
    public static IServiceCollection GetPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddDbContextPool<EmployeeRecordSystemDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(EmployeeRecordSystemDbContext))));
        return services;
    }
}
