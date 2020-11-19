using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface IDaysOfMonthExpressionBuilder
    {
        IDaysOfMonthExpressionBuilder AtSpecifiedDaysOfMonth(IEnumerable<int> daysOfMonth);
        IDaysOfMonthExpressionBuilder BetweenDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end);
        IDaysOfMonthExpressionBuilder DayBeforeLastDayOfMonth();
        IDaysOfMonthExpressionBuilder EveryDayOfMonth();
        IDaysOfMonthExpressionBuilder EveryNDaysOfMonth([Range(1, 31)] int startingAtDay, [Range(1, 31)] int interval);
        IDaysOfMonthExpressionBuilder EveryNDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end, [Range(1, 31)] int interval);
        IDaysOfMonthExpressionBuilder LastDayOfMonth();
        IDaysOfMonthExpressionBuilder LastWeekDayOfMonth();
        IDaysOfMonthExpressionBuilder NDaysBeforeLastDayOfMonth([Range(1, 31)] int daysBeforeLastDay);
        IDaysOfMonthExpressionBuilder NWeekdaysBeforeLastDayOfMonth([Range(1, 31)] int weekdaysBeforeLastDay);
        IDaysOfMonthExpressionBuilder WeekDayClosestToADate([Range(1, 31)] int dateofAMonth);
    }
}