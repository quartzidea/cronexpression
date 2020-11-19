using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface IDaysOfWeekExpressionBuilder
    {
        IDaysOfWeekExpressionBuilder AtSpecifiedDaysOfWeek(IEnumerable<DayOfWeek> daysOfWeek);
        IDaysOfWeekExpressionBuilder BetweenDaysOfWeek(DayOfWeek start, DayOfWeek end);
        IDaysOfWeekExpressionBuilder EveryNDaysSyartingAtDayOfWeek(DayOfWeek startAtWeekDay, [Range(1, 7)] int interval);
        IDaysOfWeekExpressionBuilder LastSpecfiedDayOfWeekOfAMonth(DayOfWeek lastDayOfWeekOfTheMonth);
        IDaysOfWeekExpressionBuilder NthDayOfWeekOfAMonth(DayOfWeek dayOfWeek, [Range(1, 5)] int numberN);
        IDaysOfWeekExpressionBuilder WeekDays();
        IDaysOfWeekExpressionBuilder WeekEnds();
    }
}