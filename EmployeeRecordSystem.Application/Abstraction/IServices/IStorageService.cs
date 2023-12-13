using Microsoft.AspNetCore.Http;

namespace EmployeeRecordSystem.Application.Abstraction.IServices;

public interface IStorageService
{
    Task<string> UploadFileAsync(IFormFile file);
    Task<string> UploadFilesAsync(IFormFileCollection files);
    Task<bool> DeleteFileAsync(string filePath);
    Task<int> DeleteFilesAsync(List<string> filePaths);
}
