using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface IMonthsExpressionBuilder
    {
        IMonthsExpressionBuilder AtSpecifiedMonths(IEnumerable<MonthOfYear> months);
        IMonthsExpressionBuilder BetweenMonths(MonthOfYear start, MonthOfYear end);
        IMonthsExpressionBuilder EveryMonth();
        IMonthsExpressionBuilder EveryNMonths(MonthOfYear startingAtMonth, [Range(1, 12)] int interval);
        IMonthsExpressionBuilder EveryNMonths(MonthOfYear start, MonthOfYear end, [Range(1, 59)] int interval);
    }
}