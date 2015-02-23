using System;
using System.Globalization;
using System.Threading;
using DryPants.Extensions;

namespace DryPants.Core
{
    public class Calendar
    {
        private readonly CultureInfo _culture;
        private readonly Func<DateTime> _systemTimeResolver;

        public Calendar(CultureInfo culture)
            : this(culture, SystemTime.Now)
        {

        }

        internal Calendar(CultureInfo culture, Func<DateTime> systemTimeResolver)
        {
            _culture = culture;
            _systemTimeResolver = systemTimeResolver;
        }

        public DateTime Yesterday
        {
            get { return Today.AddDays(-1); }
        }

        private DateTime Today
        {
            get { return _systemTimeResolver().Date; }
        }

        public DateTime Tomorrow
        {
            get { return Today.AddDays(1); }
        }

        public DateTime NextWorkday
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

        public DateTime PreviousWorkday
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

        public int WeekNumber
        {
            get
            {
                return _culture.Calendar.GetWeekOfYear(Today,
                                                            _culture.DateTimeFormat.CalendarWeekRule,
                                                            _culture.DateTimeFormat.FirstDayOfWeek);
            }
        }

        public DateTime NextWeek
        {
            get { return Today.AddDays(7); }
        }

        public DateTime PreviousWeek
        {
            get { return Today.AddDays(-7); }
        }
        
        public int DaysInCurrentMonth
        {
            get { return Today.GetDaysInMonth(); }
        }

        public DateTime NextMonth
        {
            get { return Today.AddMonths(1); }
        }

        public DateTime PreviousMonth
        {
            get { return Today.AddMonths(-1); }
        }

        public int DaysInCurrentYear
        {
            get { return Today.GetDaysInYear(); }
        }

        public bool CurrentYearIsLeapYear
        {
            get { return Today.IsLeapYear(); }
        }

    }
}