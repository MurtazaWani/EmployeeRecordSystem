using EmployeeRecordSystem.Application.Abstraction.IServices;
using Microsoft.AspNetCore.Http;

namespace EmployeeRecordSystem.Application.Services;

public class StorageService : IStorageService
{
    private readonly string webRootPath;

    public StorageService(string webRootPath)
    {
        this.webRootPath = webRootPath;
    }
    public async Task<bool> DeleteFileAsync(string filePath)
    {
        if(File.Exists(filePath))
        {
            await Task.Run(() => { File.Delete(filePath); });
            return true;
        }
        return false;
    }

    public async Task<int> DeleteFilesAsync(List<string> filePaths)
    {
        int count = 0;
        foreach(var filePath in filePaths)
        {
            if(File.Exists(filePath))
            {
                await Task.Run(() => { File.Delete(filePath); });
                count++;
            }
        }
        return count;
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        string dirPath = GetPhysicalPathDirectory();
        // validate file
        string extension = Path.GetExtension(file.FileName);
        string fileName = string.Concat(Guid.NewGuid(), extension);
        string fullPath = Path.Combine(dirPath, fileName);
        FileStream fs = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(fs);
        return Path.Combine(GetVirtualDirectoryPath(), fileName);
        //return GetVirtualDirectoryPath() + fileName;
    }

    public Task<string> UploadFilesAsync(IFormFileCollection files)
    {
        throw new NotImplementedException();
    }

    private string GetPhysicalPathDirectory()
    {
        var dirPath = Path.Combine(webRootPath, "Files");
        if (Directory.Exists(dirPath))
        {
            return dirPath;
        }
        Directory.CreateDirectory(dirPath);
        return dirPath;
    }

    private void ValidateFile(IFormFile file, string contentType)
    {
        string extension = Path.GetExtension(file.FileName).ToLower();
        long length = 0;
        var size = file.Length;

        if(!file.ContentType.Contains("image"))
        {
            throw new Exception("File format not supported");
        }
        if(file.ContentType.Contains("images"))
        {
            length = 200000;
        }
        if(file.ContentType.Contains("video"))
        {
            length = 10000000;
        }
        if(file.ContentType.Contains("application/pdf"))
        {
            length = 5000000;
        }
        if(size > length)
        {
            throw new Exception("File size exceeded the limit");
        }
    }

    private string GetVirtualDirectoryPath() => "/Files/";
}
