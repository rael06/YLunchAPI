namespace YLunchApi.Authentication.Utils;

public static class DateTimeUtils
{
    public static DateTime ConvertUnixTimeStampToDateTime(long unixTimeStamp)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds(unixTimeStamp);
    }
}