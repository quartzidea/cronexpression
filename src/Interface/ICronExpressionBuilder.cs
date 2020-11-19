using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface ICronExpressionBuilder : ICronosExpression, IExpressionBuilder
    {
        ICronExpressionBuilder AtSpecifiedDaysOfMonth(IEnumerable<int> daysOfMonth);
        ICronExpressionBuilder AtSpecifiedDaysOfWeek(IEnumerable<DayOfWeek> daysOfWeek);
        ICronExpressionBuilder AtSpecifiedHours(IEnumerable<int> hours);
        ICronExpressionBuilder AtSpecifiedMinutes(IEnumerable<int> minutes);
        ICronExpressionBuilder AtSpecifiedMonths(IEnumerable<MonthOfYear> months);
        ICronExpressionBuilder AtSpecifiedSeconds(IEnumerable<int> seconds);
        ICronExpressionBuilder BetweenDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end);
        ICronExpressionBuilder BetweenDaysOfWeek(DayOfWeek start, DayOfWeek end);
        ICronExpressionBuilder BetweenHours([Range(0, 23)] int start, [Range(0, 23)] int end);
        ICronExpressionBuilder BetweenMinutes([Range(0, 59)] int start, [Range(0, 59)] int end);
        ICronExpressionBuilder BetweenMonths(MonthOfYear start, MonthOfYear end);
        ICronExpressionBuilder BetweenSeconds([Range(0, 59)] int start, [Range(0, 59)] int end);

        ICronExpressionBuilder DayBeforeLastDayOfMonth();
        ICronExpressionBuilder EveryDayOfMonth();
        ICronExpressionBuilder EveryHour();
        ICronExpressionBuilder EveryMinute();
        ICronExpressionBuilder EveryMonth();
        ICronExpressionBuilder EveryNDaysOfMonth([Range(1, 31)] int startingAtDay, [Range(1, 31)] int interval);
        ICronExpressionBuilder EveryNDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end, [Range(1, 31)] int interval);
        ICronExpressionBuilder EveryNDaysSyartingAtDayOfWeek(DayOfWeek startAtWeekDay, [Range(1, 7)] int interval);
        ICronExpressionBuilder EveryNHours([Range(0, 23)] int startingAtHour, [Range(1, 23)] int interval);
        ICronExpressionBuilder EveryNHours([Range(0, 23)] int start, [Range(0, 23)] int end, [Range(1, 23)] int intervaL);
        ICronExpressionBuilder EveryNMinutes([Range(0, 59)] int startingAtMinute, [Range(1, 59)] int interval);
        ICronExpressionBuilder EveryNMinutes([Range(0, 59)] int start, [Range(0, 59)] int end, [Range(1, 59)] int interval);
        ICronExpressionBuilder EveryNMonths(MonthOfYear startingAtMonth, [Range(1, 12)] int interval);
        ICronExpressionBuilder EveryNMonths(MonthOfYear start, MonthOfYear end, [Range(1, 59)] int interval);
        ICronExpressionBuilder EveryNSeconds([Range(0, 59)] int startingAtSecond, [Range(1, 59)] int interval);
        ICronExpressionBuilder EveryNSeconds([Range(0, 59)] int start, [Range(0, 59)] int end, [Range(1, 59)] int interval);
        ICronExpressionBuilder EverySecond();
        ICronExpressionBuilder LastDayOfMonth();
        ICronExpressionBuilder LastSpecfiedDayOfWeekOfAMonth(DayOfWeek lastDayOfWeekOfTheMonth);
        ICronExpressionBuilder LastWeekDayOfMonth();
        ICronExpressionBuilder NDaysBeforeLastDayOfMonth([Range(1, 31)] int daysBeforeLastDay);
        ICronExpressionBuilder NthDayOfWeekOfAMonth(DayOfWeek dayOfWeek, [Range(1, 5)] int numberN);
        ICronExpressionBuilder NWeekdaysBeforeLastDayOfMonth([Range(1, 31)] int weekdaysBeforeLastDay);
        ICronExpressionBuilder WeekDayClosestToADate([Range(1, 31)] int dateofAMonth);
        ICronExpressionBuilder WeekDays();
        ICronExpressionBuilder WeekEnds();
    }
}

