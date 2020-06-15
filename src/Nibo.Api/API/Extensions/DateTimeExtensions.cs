using System;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateString(this DateTime dateTime, string format = "dd/MM/yyyy") =>
            dateTime.ToString(format);

        public static DateTime ConvertOfxDateToDateTime(this string ofxDate)
        {
            int year = Convert.ToInt16(ofxDate.Substring(0, 4));
            int month = Convert.ToInt16(ofxDate.Substring(4, 2));
            int day = Convert.ToInt16(ofxDate.Substring(6, 2));
            int hours = Convert.ToInt16(ofxDate.Substring(8, 2));
            int minutes = Convert.ToInt16(ofxDate.Substring(10, 2));
            int seconds = Convert.ToInt16(ofxDate.Substring(12, 2));

            return new DateTime(year, month, day, hours, minutes, seconds);
        }
    }
}
