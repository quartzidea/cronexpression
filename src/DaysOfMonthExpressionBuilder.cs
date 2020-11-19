using Schedule.CronExpressionBuilder.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder
{
    public class DaysOfMonthExpressionBuilder : CronExpressionBuilder, IDaysOfMonthExpressionBuilder
    {
        /// <summary>
        /// expression for every day - *
        /// </summary>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.EveryDayOfMonth()
        {
            base.EveryDayOfMonth();
            return this;
        }

        /// <summary>
        /// Every n day starting at some day of a month e.g. every 3 day starting 1st day of the month
        /// </summary>
        /// <param name="startingAtDay"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.EveryNDaysOfMonth([Range(1, 31)] int startingAtDay, [Range(1, 31)] int interval)
        {
            base.EveryNDaysOfMonth(startingAtDay, interval);
            return this;
        }

        /// <summary>
        /// At specified days of a month, between 1 to 31 of specified/every month - 0,2,4,5.
        /// </summary>
        /// <param name="daysOfMonth"></param>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.AtSpecifiedDaysOfMonth(IEnumerable<int> daysOfMonth)
        {
            base.AtSpecifiedDaysOfMonth(daysOfMonth);
            return this;
        }

        /// <summary>
        /// Every n day(s) between some dates e.g. every 2 days(s) between date 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.EveryNDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end,[Range(1, 31)] int interval)
        {
            base.EveryNDaysOfMonth(start, end, interval);
            return this;
        }

        /// <summary>
        /// Last day of specified/every month.
        /// </summary>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.LastDayOfMonth()
        {
            base.LastDayOfMonth();
            return this;
        }

        /// <summary>
        /// Last week day of specified/every month.
        /// </summary>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.LastWeekDayOfMonth()
        {
            base.LastWeekDayOfMonth();
            return this;
        }


        /// <summary>
        /// Day before last day of specified/every month.
        /// </summary>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.DayBeforeLastDayOfMonth()
        {
            base.DayBeforeLastDayOfMonth();
            return this;
        }

        /// <summary>
        /// n day(s) before last day of specified/every month.
        /// </summary>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.NDaysBeforeLastDayOfMonth([Range(1, 31)] int daysBeforeLastDay)
        {
            base.NDaysBeforeLastDayOfMonth(daysBeforeLastDay);
            return this;
        }

        /// <summary>
        /// N weekday(s) before last day of specified/every month.
        /// </summary>
        /// <param name="weekdaysBeforeLastDay"></param>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.NWeekdaysBeforeLastDayOfMonth(Int32 weekdaysBeforeLastDay)
        {
            base.NWeekdaysBeforeLastDayOfMonth(weekdaysBeforeLastDay);
            return this;
        }

        /// <summary>
        /// Week day close to a specified date of specified/every month.
        /// </summary>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.WeekDayClosestToADate([Range(1, 31)] int dateOfAMonth)
        {
            base.WeekDayClosestToADate(dateOfAMonth);
            return this;
        }

        /// <summary>
        /// Between days of the specified/every month(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        IDaysOfMonthExpressionBuilder IDaysOfMonthExpressionBuilder.BetweenDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end)
        {
            base.BetweenDaysOfMonth(start, end);
            return this;
        }
    }
}