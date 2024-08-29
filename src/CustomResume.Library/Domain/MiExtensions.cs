namespace CustomResume.Library.Domain;

public static class MiExtensions
{
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => string.Empty,
            "" => input,
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
}
