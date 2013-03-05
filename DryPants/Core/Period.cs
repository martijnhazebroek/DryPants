using System;
using DryPants.Resources;

namespace DryPants.Core
{
    public struct Period : IEquatable<Period>
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public Period(DateTime startDate, DateTime endDate)
        {
            if(startDate > endDate)
                throw new InvalidOperationException(Errors.Period_StartDatePastEndDate);

            _startDate = startDate.Date;
            _endDate = endDate.Date;
        }

        public DateTime StartDate
        {
            get { return _startDate; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Period)
            {
                return Equals((Period)obj);
            }
            return false;
        }

        public bool Equals(Period other)
        {
            return _startDate.Equals(other._startDate) && _endDate.Equals(other._endDate);
        }

        public override int GetHashCode()
        {
            return _startDate.GetHashCode() ^ _endDate.GetHashCode();
        }

        public override string ToString()
        {
            return _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();
        }

        public static bool operator ==(Period left, Period right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Period left, Period right)
        {
            return !left.Equals(right);
        }
    }
}
