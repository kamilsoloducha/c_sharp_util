using System;

namespace Util
{
    public static class DateTimeExtention
    {

        public static DateTime GetDateTime(int year = 1990, int month = 9, int day = 24, int hour = 12, int min = 0, int sec = 0)
        {
            return new DateTime(year, month, day, hour, min, sec);
        }

    }
}
