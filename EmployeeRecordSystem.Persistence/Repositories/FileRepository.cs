using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Persistence.Data;

namespace EmployeeRecordSystem.Persistence.Repositories;

public class FileRepository : BaseRepository<AppFiles>, IFileRepository
{
    public FileRepository(EmployeeRecordSystemDbContext context) : base(context)
    {

    }
}
