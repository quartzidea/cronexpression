using Schedule.CronExpressionBuilder.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder
{
    public class MonthsExpressionBuilder : CronExpressionBuilder, IMonthsExpressionBuilder
    {
        /// <summary>
        /// Every month of the year.
        /// </summary>
        /// <returns></returns>
        IMonthsExpressionBuilder IMonthsExpressionBuilder.EveryMonth()
        {
            base.EveryMonth();
            return this;
        }

        /// <summary>
        /// Every n month(s) starting at some month e.g. every 2 month(s) interval starting from June - 6/2 - 6,8,10,12....
        /// </summary>
        /// <returns></returns>
        IMonthsExpressionBuilder IMonthsExpressionBuilder.EveryNMonths(MonthOfYear startingAtMonth, [Range(1, 12)] int interval)
        {
            base.EveryNMonths(startingAtMonth, interval);
            return this;
        }

        /// <summary>
        /// At specified minutes between 0 to 59 of specified/every hour - 0,2,4,5.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        IMonthsExpressionBuilder IMonthsExpressionBuilder.AtSpecifiedMonths(IEnumerable<MonthOfYear> months)
        {
            base.AtSpecifiedMonths(months);
            return this;
        }

        /// <summary>
        /// Every n month(s) between some months e.g. every 2 month(s) between month 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        IMonthsExpressionBuilder IMonthsExpressionBuilder.EveryNMonths(MonthOfYear start, MonthOfYear end, [Range(1, 59)] int interval)
        {
            base.EveryNMonths(start, end, interval);
            return this;
        }

        /// <summary>
        /// Between some months of the year e.g. Jan to May - JAN-MAY
        /// </summary>
        /// <returns></returns>
        IMonthsExpressionBuilder IMonthsExpressionBuilder.BetweenMonths(MonthOfYear start, MonthOfYear end)
        {
            base.BetweenMonths(start, end);
            return this;
        }
    }
}