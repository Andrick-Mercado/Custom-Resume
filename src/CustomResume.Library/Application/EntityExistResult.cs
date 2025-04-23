namespace CustomResume.Library.Application;

public class EntityExistResult<T>
{
    public T Data { get; }
    public bool IsFound { get; }
    public bool IsNotFound => IsFound is false;
    public bool IsSuccessful { get; }
    public bool IsNotSuccessful => IsSuccessful is false;
    public List<string> Errors { get; }
    public HttpStatusResult HttpResult { get; }

    private EntityExistResult(T data, bool isFound, bool isSuccessful, List<string> errors = null,
        HttpStatusResult httpResult = HttpStatusResult.NotApplicable)
    {
        Data = data;
        IsFound = isFound;
        IsSuccessful = isSuccessful;
        Errors = errors ?? [];
        HttpResult = httpResult;
    }

    public static EntityExistResult<T> NotFound(bool isSuccessful, List<string> errors = null) =>
        new(default, false, isSuccessful, errors);

    public static EntityExistResult<T> Found(T data) => new(data, true, true);
}