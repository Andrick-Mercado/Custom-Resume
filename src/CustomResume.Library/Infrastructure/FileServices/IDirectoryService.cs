using CustomResume.Library.Application;

namespace CustomResume.Library.Infrastructure.FileServices;

public interface IDirectoryService<T>
{
    Task<EntityExistResult<T>> ReadFileAsync(string filePathName);
    Task<Result<bool>> WriteFileAsync(string filePath, T data);
    Task<Result<bool>> WriteBytesAsync(string filePath, byte[] data);
    Result<bool> DeleteFileAsync(string filePath);
}