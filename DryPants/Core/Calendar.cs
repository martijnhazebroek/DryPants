using System;
using System.Globalization;
using DryPants.Extensions;

namespace DryPants.Core
{
    public static class Calendar
    {
        #region Fields

        private static readonly Func<DateTime> DateTimeFunc;
        private static readonly CultureInfo ActiveCulture;

        #endregion

        #region Constructors

        static Calendar()
        {
            DateTimeFunc = SystemTime.Today;
            ActiveCulture = CultureInfo.CurrentCulture;
        }

        #endregion

        #region Days

        public static DateTime Yesterday
        {
            get { return Today.AddDays(-1); }
        }

        private static DateTime Today
        {
            get { return DateTimeFunc(); }
        }

        public static DateTime Tomorrow
        {
            get { return Today.AddDays(1); }
        }

        public static DateTime NextWorkday
        {
            get
            {
                DateTime nextDay = Tomorrow;
                while (!nextDay.IsWorkday())
                {
                    nextDay = nextDay.AddDays(1);
                }
                return nextDay;
            }
        }

        public static DateTime PreviousWorkday
        {
            get
            {
                DateTime previousDay = Yesterday;
                while (!previousDay.IsWorkday())
                {
                    previousDay = previousDay.AddDays(-1);
                }
                return previousDay;
            }
        }

        #endregion

        #region Weeks

        public static int Weeknumber
        {
            get
            {
                return ActiveCulture.Calendar.GetWeekOfYear(Today,
                                                            ActiveCulture.DateTimeFormat.CalendarWeekRule,
                                                            ActiveCulture.DateTimeFormat.FirstDayOfWeek);
            }
        }

        public static DateTime NextWeek
        {
            get { return Today.AddDays(7); }
        }

        public static DateTime PreviousWeek
        {
            get { return Today.AddDays(-7); }
        }

        #endregion

        #region Months

        public static int DaysInCurrentMonth
        {
            get { return Today.GetDaysInMonth(); }
        }

        public static DateTime NextMonth
        {
            get { return Today.AddMonths(1); }
        }

        public static DateTime PreviousMonth
        {
            get { return Today.AddMonths(-1); }
        }

        #region Year

        public static int DaysInCurrentYear
        {
            get { return Today.GetDaysInYear(); }
        }

        public static bool CurrentYearIsLeapYear
        {
            get { return Today.IsLeapYear(); }
        }

        #endregion

        #endregion
    }
}