using AutoMapper;
using EmployeeRecordSystem.Application.Abstraction.IRepositories;
using EmployeeRecordSystem.Application.Abstraction.IServices;
using EmployeeRecordSystem.Application.RRModels;
using EmployeeRecordSystem.Domain.Entities;
using EmployeeRecordSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace EmployeeRecordSystem.Application.Services;

public class FileService : IFileService
{
    private readonly IFileRepository fileRepository;
    private readonly IMapper mapper;
    private readonly IStorageService storageService;

    public FileService(IFileRepository fileRepository, IMapper mapper, IStorageService storageService)
    {
        this.fileRepository = fileRepository;
        this.mapper = mapper;
        this.storageService = storageService;
    }
    public async Task<bool> DeleteFileAsync(Guid id, string filePath)
    {
        await fileRepository.DeleteAsync(id);
        return await storageService.DeleteFileAsync(filePath);
    }

    public async Task<int> DeleteFilesAsync(List<Guid> ids, List<string> filePaths)
    {
        List<AppFiles> appFiles = new List<AppFiles>();
        foreach (var id in ids)
        {
            appFiles.Add(new AppFiles { Id = id });
        }
        await fileRepository.DeleteRangeAsync(appFiles);
        return await storageService.DeleteFilesAsync(filePaths);
    }

    public async Task<AppFileResponse> UploadFileAync(AppModule module, Guid entityId, IFormFile file)
    {
        string filePath = await storageService.UploadFileAsync(file);
        AppFiles appFiles = new()
        {
            EntityId = entityId,
            Module = module,
            FilePath = filePath
        };
        int res = await fileRepository.AddAsync(appFiles);
        var appFileResponse = mapper.Map<AppFileResponse>(appFiles);
        return appFileResponse;
    }

    public Task<IEnumerable<AppFileResponse>> UploadFilesAync(AppModule module, Guid entityId, IFormFileCollection files)
    {
        throw new NotImplementedException();
    }
}
