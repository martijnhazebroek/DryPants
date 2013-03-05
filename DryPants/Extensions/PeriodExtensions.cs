using System;
using DryPants.Core;
using DryPants.Exceptions;

namespace DryPants.Extensions
{
    public static class PeriodExtensions
    {
        /// <summary>
        /// Performs the specicied action on each month of the <see cref="Period"/>
        /// </summary>
        /// <param name="source">The period this extension method applies to.</param>
        /// <param name="action">
        ///     The <see cref="T:System.Action`Period"/> delegate to perform on each month in the period.
        ///     The <see cref="Period"/> that is passed to the action contains the Start- and EndDate of the month being iterated, except for the last month.
        ///     The EndDate of the last month equals the EndDate of the source period. 
        /// </param>
        public static void EachMonth(this Period source, Action<Period> action)
        {
            Throw.IfArgumentNull(() => action);

            var currentPeriod = new Period(source.StartDate, 
                DateTimeExtensions.Min(source.EndDate, source.StartDate.LastDayOfMonth()));

            while (currentPeriod.StartDate <= source.EndDate)
            {
                action(currentPeriod);

                DateTime newPeriodStartDate = currentPeriod.EndDate.AddDays(1);
                DateTime newPeriodEndDate = DateTimeExtensions.Min(source.EndDate, newPeriodStartDate.LastDayOfMonth());
                if (newPeriodStartDate > newPeriodEndDate) break;

                currentPeriod = new Period(newPeriodStartDate, newPeriodEndDate);
            }
        }
    }
}