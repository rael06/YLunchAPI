namespace YLunchApi.Authentication.Utils;

public static class RandomUtils
{
    public static string GetRandomString(int lenght)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, lenght)
            .Select(x => x[random.Next(x.Length)]).ToArray());
    }
}
