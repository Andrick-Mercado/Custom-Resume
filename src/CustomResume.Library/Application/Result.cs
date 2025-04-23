namespace CustomResume.Library.Application;

public enum HttpStatusResult
{
    NotApplicable,
    SuccessfulRequestWithContent,
    SuccessfulRequestWithNoContent,
    BadRequest,
    TooManyRequest,
    ServerError,
    Unauthorized,
    PreconditionFailed,
    NotFound
}

public class Result<T>
{
    public T Data { get; }
    public bool IsSuccessful { get; }
    public bool IsNotSuccessful => IsSuccessful is false;
    public List<string> Errors { get; }
    public HttpStatusResult HttpResult { get; }

    private Result(T data, bool isValid, List<string> errors = null, HttpStatusResult httpResult = HttpStatusResult.NotApplicable)
    {
        Data = data;
        IsSuccessful = isValid;
        Errors = errors ?? [];
        HttpResult = httpResult;
    }

    public static Result<T> NotSuccessful(List<string> errors = null, HttpStatusResult httpResult = HttpStatusResult.NotApplicable) =>
        new(default, false, errors, httpResult);

    public static Result<T> Successful(T data, HttpStatusResult httpStatusResult = HttpStatusResult.NotApplicable) =>
        new(data, true, null, httpStatusResult);
}