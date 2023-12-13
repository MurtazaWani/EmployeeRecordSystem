using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Abstraction.IServices;

public interface IFileService
{
    Task<AppFileResponse> UploadFileAync(AppModule module, Guid entityId, IFormFile file);
    Task<IEnumerable<AppFileResponse>> UploadFilesAync(AppModule module, Guid entityId, IFormFileCollection files);
    Task<bool> DeleteFileAsync(Guid id, string filePath);
    Task<int> DeleteFilesAsync(List<Guid> ids, List<string> filePaths);
}
