using Schedule.CronExpressionBuilder.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder
{
    public class DaysOfWeekExpressionBuilder : CronExpressionBuilder, IDaysOfWeekExpressionBuilder
    {
        /// <summary>
        /// Every N day(s) starting at specified day of a week e.g. 2 days starting from Monday - 2/2 - Monday, Wednesday ...
        /// </summary>
        /// <returns></returns>
        IDaysOfWeekExpressionBuilder IDaysOfWeekExpressionBuilder.EveryNDaysSyartingAtDayOfWeek(DayOfWeek startAtWeekDay, [Range(1, 7)] int interval)
        {
            base.EveryNDaysSyartingAtDayOfWeek(startAtWeekDay,interval);
            return this;
        }


        /// <summary>
        /// Every weekdays - Monday to Friday
        /// </summary>
        /// <returns></returns>
        IDaysOfWeekExpressionBuilder IDaysOfWeekExpressionBuilder.WeekDays()
        {
            base.WeekDays();
            return this;
        }

        /// <summary>
        /// Every weekends - Saturday, Sunday
        /// </summary>
        /// <returns></returns>
        IDaysOfWeekExpressionBuilder IDaysOfWeekExpressionBuilder.WeekEnds()
        {
            base.WeekEnds();
            return this;
        }


        /// <summary>
        /// Every weekends - Saturday, Sunday
        /// </summary>
        /// <returns></returns>
        IDaysOfWeekExpressionBuilder IDaysOfWeekExpressionBuilder.AtSpecifiedDaysOfWeek(IEnumerable<DayOfWeek> daysOfWeek)
        {
            base.AtSpecifiedDaysOfWeek(daysOfWeek);
            return this;
        }

        /// <summary>
        /// Last specified day of week e.g. last monday of the month.
        /// </summary>
        /// <param name="lastDayOfWeekOfTheMonth"></param>
        /// <returns></returns>
        IDaysOfWeekExpressionBuilder IDaysOfWeekExpressionBuilder.LastSpecfiedDayOfWeekOfAMonth(DayOfWeek lastDayOfWeekOfTheMonth)
        {
            base.LastSpecfiedDayOfWeekOfAMonth(lastDayOfWeekOfTheMonth);
            return this;
        }

        /// <summary>
        /// Nth day of Week of the month e.g. 2nd Monday of the Month.
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <param name="numberN"></param>
        /// <returns></returns>
        IDaysOfWeekExpressionBuilder IDaysOfWeekExpressionBuilder.NthDayOfWeekOfAMonth(DayOfWeek dayOfWeek,[Range(1, 5)] int numberN)
        {
            base.NthDayOfWeekOfAMonth(dayOfWeek,numberN);
            return this;
        }

        /// <summary>
        /// Between days of the week e.g. Tuesday - Friday
        /// </summary>
        /// <returns></returns>
        IDaysOfWeekExpressionBuilder IDaysOfWeekExpressionBuilder.BetweenDaysOfWeek(DayOfWeek start, DayOfWeek end)
        {
            base.BetweenDaysOfWeek( start,  end);
            return this;
        }
    }
}