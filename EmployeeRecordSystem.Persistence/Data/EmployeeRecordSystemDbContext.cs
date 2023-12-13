using EmployeeRecordSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordSystem.Persistence.Data;

public class EmployeeRecordSystemDbContext : DbContext
{
    public EmployeeRecordSystemDbContext(DbContextOptions<EmployeeRecordSystemDbContext> options) : base(options)
    {
        
    }

    // Db Sets

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AppFiles> AppFiles { get; set; }
}
