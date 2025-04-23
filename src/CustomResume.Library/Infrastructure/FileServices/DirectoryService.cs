using CustomResume.Library.Application;
using CustomResume.Library.Infrastructure.Extensions;
using Microsoft.Maui.Storage;

namespace CustomResume.Library.Infrastructure.FileServices;

public interface IDirectoryService<T>
{
    Task<EntityExistResult<T>> ReadFileAsync(string filePathName);
    Task<Result<bool>> WriteFileAsync(string filePath, T data);
    Result<bool> DeleteFileAsync(string filePath);
}

public class DirectoryService<T> : IDirectoryService<T>
{
    private readonly string _directoryPath;

    public DirectoryService()
    {
        var appDataDirectory = FileSystem.Current.AppDataDirectory;
        _directoryPath = appDataDirectory;
    }

    public async Task<EntityExistResult<T>> ReadFileAsync(string filePathName)
    {
        try
        {
            var fullPath = Path.Combine(_directoryPath, filePathName);
            Console.WriteLine("fullPath: " + fullPath);

            if (File.Exists(fullPath) is false)
                return EntityExistResult<T>.NotFound(true, ["File not found"]);

            var fileContent = await File.ReadAllTextAsync(fullPath);
            var data = fileContent.DeserializeWithCamelCase<T>();
            return EntityExistResult<T>.Found(data);
        }
        catch (Exception ex)
        {
            return EntityExistResult<T>.NotFound(false, [ex.Message]);
        }
    }

    public async Task<Result<bool>> WriteFileAsync(string filePath, T data)
    {
        try
        {
            var fullPath = Path.Combine(_directoryPath, filePath);
            var directoryPath = Path.GetDirectoryName(fullPath);

            if (string.IsNullOrEmpty(directoryPath) is false)
                Directory.CreateDirectory(directoryPath);

            var fileContent = data.Serialize();
            await File.WriteAllTextAsync(fullPath, fileContent);

            return Result<bool>.Successful(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.NotSuccessful([ex.Message]);
        }
    }

    public Result<bool> DeleteFileAsync(string filePath)
    {
        try
        {
            var fullPath = Path.Combine(_directoryPath, filePath);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Result<bool>.Successful(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.NotSuccessful([ex.Message]);
        }
    }
}