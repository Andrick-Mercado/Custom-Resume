using System.Text.Json;
using CustomResume.Library.Infrastructure.Extensions;

namespace CustomResume.Library.Infrastructure;

public interface IDirectoryService<T>
{
    Task<T> ReadFileAsync(string filePath);
    Task WriteFileAsync(string filePath, T data);
    Task DeleteFileAsync(string filePath);
}

public class DirectoryService<T> : IDirectoryService<T>
{
    private readonly string _directoryPath;

    public DirectoryService(string directoryPath)
    {
        _directoryPath = directoryPath;
    }

    public async Task<T> ReadFileAsync(string filePath)
    {
        var fullPath = Path.Combine(_directoryPath, filePath);
        if (File.Exists(fullPath) is false)
        {
            return default;
        }

        var fileContent = await File.ReadAllTextAsync(fullPath);
        return fileContent.DeserializeWithCamelCase<T>();
    }

    public async Task WriteFileAsync(string filePath, T data)
    {
        var fullPath = Path.Combine(_directoryPath, filePath);
        var fileContent = JsonSerializer.Serialize(data);
        await File.WriteAllTextAsync(fullPath, fileContent);
    }

    public Task DeleteFileAsync(string filePath)
    {
        var fullPath = Path.Combine(_directoryPath, filePath);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        return Task.CompletedTask;
    }
}