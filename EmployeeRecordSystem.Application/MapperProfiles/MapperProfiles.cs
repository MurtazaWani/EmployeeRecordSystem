using AutoMapper;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.MapperProfile;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}

public sealed class AppFileProfile : Profile
{
    public AppFileProfile()
    {
        CreateMap<AppFiles, AppFileResponse>();
    }
}

public sealed class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<Employee, EmployeeResponse>();
    }
}