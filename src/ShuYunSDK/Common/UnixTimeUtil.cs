using System;
using System.Collections.Generic;
using System.Text;

namespace ShuYunSDK.Common
{
    /// <summary>
    /// 时间工具类
    /// </summary>
    public  class UnixTimeUtil
    {
        /// <summary>
        /// 将dateTime格式转换为Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ConvertDateTimeToUnix(DateTime time)
        {
            return ((time.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();

            //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            //long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds; // 相差秒数
            //System.Console.WriteLine(timeStamp);
        }

        /// <summary>
        /// 将Unix时间戳转换为dateTime格式
        /// </summary>
        /// <param name="unix"></param>
        /// <returns></returns>
        public static DateTime ConvertUnixToDateTime(string unix,int lv = 1)
        {
            DateTime startUnixTime = System.TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);
            if (lv == 1)
            {
                return startUnixTime.AddSeconds(double.Parse(unix));
            }
            else
            {
                return startUnixTime.AddMilliseconds(double.Parse(unix));
            }
        }

        /// <summary>
        /// 将Unix时间戳转换为dateTime格式
        /// </summary>
        /// <param name="unix"></param>
        /// <param name="lv">1 秒级别 2毫秒级</param>
        /// <returns></returns>
        public static DateTime UnixToDt(string unix, int lv = 1)
        {
            DateTimeOffset datetoffset;
            if (lv == 1)
                datetoffset=  DateTimeOffset.FromUnixTimeSeconds(long.Parse(unix));
            else
                datetoffset =  DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(unix));

            return datetoffset.LocalDateTime;

        }

        /// <summary>
        /// 将dateTime格式转换为Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <param name="lv">1 秒级别 2毫秒级</param>
        /// <returns></returns>
        public static string DtToUnix(DateTime time,int lv = 1)
        {
            DateTimeOffset dtoNow = time;
            long timeStamp;
                if(lv==1)
                timeStamp =dtoNow.ToUnixTimeSeconds(); // 相差秒数
                else
                timeStamp =dtoNow.ToUnixTimeMilliseconds(); // 相差毫秒数
            return timeStamp.ToString();
        }
    }
}
