using CustomResume.Library.Application;

namespace CustomResume.Library.Infrastructure.FileServices;

public class BrowserDirectoryService<T> : IDirectoryService<T>
{
    public Task<EntityExistResult<T>> ReadFileAsync(string filePathName)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> WriteFileAsync(string filePath, T data)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> WriteBytesAsync(string filePath, byte[] data)
    {
        throw new NotImplementedException();
    }

    public Result<bool> DeleteFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }
}