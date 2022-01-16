namespace YLunchApi.Domain.Core.Utils;

public static class StringExtension
{
    public static string Capitalize(this string value)
    {
        return string.Join("-", value.Split("-").Select(CapitalizePart));
    }

    private static string CapitalizePart(string value)
    {
        return value.Length switch
        {
            0 => string.Empty,
            1 => char.ToUpper(value[0]).ToString(),
            _ => char.ToUpper(value[0]) + value[1..].ToLower()
        };
    }
}
