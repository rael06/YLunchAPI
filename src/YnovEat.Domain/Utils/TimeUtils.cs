using System;

namespace YnovEat.Domain.Utils
{
    public static class TimeUtils
    {
        public static string ToStrTime(int? minutes)
        {
            if (minutes == null) return null;

            var result = TimeSpan.FromMinutes((double) minutes);

            return result.ToString(@"hh\:mm");
        }

        public static int ToMinutes(string time)
        {
            var timeSpan = TimeSpan.Parse(time);
            return timeSpan.Hours * 60 + timeSpan.Minutes;
        }

        public static int? ToNullableMinutes(string time)
        {
            if (time == null) return null;

            return ToMinutes(time);
        }
    }
}
