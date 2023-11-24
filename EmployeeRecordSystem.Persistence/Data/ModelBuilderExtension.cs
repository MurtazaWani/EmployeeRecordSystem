using EmployeeRecordSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Persistence.Data;

internal static class ModelBuilderExtension
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        Guid id  = Guid.NewGuid();
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = id,
            Username = "admin",
            Phone = "123456",
            Email = "murtazas899@gmail.com",
            Password = "admin",
            CreatedBy = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            UserStatus = Domain.Enums.UserStatus.Active,
        });

        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = id,
            Name = "Murtaza",
            Salary = 98000,
            CreatedOn = DateTimeOffset.Now,
            CreatedBy = Guid.NewGuid(),
        });
    }
}
