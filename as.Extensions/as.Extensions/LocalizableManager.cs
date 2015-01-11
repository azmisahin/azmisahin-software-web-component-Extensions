using System;
using System.Globalization;
using System.Threading;

namespace @as.Extensions
{
    /// <summary>
    /// Localizable Manager [ Extensions ]
    /// </summary>
    public static class LocalizableManager
    {
        #region Property
        /// <summary>
        /// To Utc Convert
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        public static DateTime toUTCDate(this string strDateTime)
        {
            DateTime result;
            try
            {
                result = Convert(strDateTime);
                System.Diagnostics.Trace.Write(string.Format("DateTime: {0} - Result : {1}", strDateTime, result));
            }
            catch (Exception ex)
            {
                var e = ex;
                result = DateTime.Now;//Planing
                System.Diagnostics.Trace.Write(string.Format("DateTime: {0} - Result : {1} - Ex : {2}", strDateTime, result, ex.InnerException));
            }
            return result;
        } 
        #endregion

        #region Internal Function

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        private static DateTime Convert(string strDateTime)
        {
            DateTime result = tryPasre(strDateTime);
            result = toUniversalTime(result);
            System.Diagnostics.Trace.Write(String.Format("Convert => Date {0}  To {1}", strDateTime, result));
            return result;
        }


        /// <summary>
        /// Try Parse
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <returns></returns>
        private static DateTime tryPasre(string strDateTime)
        {
            DateTime result;
            try
            {
                setCulture("tr-TR");
                DateTime.TryParse(strDateTime, out result);
                setCulture("en-US");
            }
            catch (FormatException)
            {
                result = DateTime.UtcNow;
            }
            return result;
        }

        /// <summary>
        /// To Universal Time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private static DateTime toUniversalTime(DateTime dateTime)
        {
            return dateTime.ToUniversalTime();
        }

        /// <summary>
        /// To Local Time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private static DateTime toLocalTime(DateTime dateTime)
        {
            return dateTime.ToLocalTime();
        }

        /// <summary>
        /// Get Time Zone By Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static DateTime getTimeZone(DateTime date)
        {
            return TimeZoneInfo.ConvertTimeToUtc(date);
        }

        /// <summary>
        /// Get Time Zone By Date And Id
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static DateTime getTimeZone(DateTime date, string id)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(id);
            return TimeZoneInfo.ConvertTimeToUtc(date, timeZoneInfo);
        }

        /// <summary>
        /// This Application Culture Info
        /// </summary>
        public static CultureInfo currentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
            set { Thread.CurrentThread.CurrentCulture = value; }
        }

        /// <summary>
        /// This Application Set Culture
        /// </summary>
        /// <param name="culturName"></param>
        /// <returns></returns>
        public static CultureInfo setCulture(string culturName)
        {
            currentCulture = CultureInfo.CreateSpecificCulture(culturName);
            return currentCulture;
        }
        #endregion
    }
}
