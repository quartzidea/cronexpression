using Schedule.CronExpressionBuilder.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder
{
    public class HourExpressionBuilder : CronExpressionBuilder, IHourExpressionBuilder
    {
        /// <summary>
        /// expression for every hour - *
        /// </summary>
        /// <returns></returns>
        IHourExpressionBuilder IHourExpressionBuilder.EveryHour()
        {
            base.EveryHour();
            return this;
        }

        /// <summary>
        /// Every n hour(s) starting at some hour e.g. every 2 hour(s) starting at 08:00  - 8/2 - 8,10,12,....
        /// </summary>
        /// <returns></returns>
        IHourExpressionBuilder IHourExpressionBuilder.EveryNHours([Range(0, 23)] int startingAtHour, [Range(1, 23)] int interval)
        {
            base.EveryNHours(startingAtHour, interval);
            return this;
        }

        /// <summary>
        /// At specified hours between 0 to 23 of a specified/every day - 0,2,4,5.
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        IHourExpressionBuilder IHourExpressionBuilder.AtSpecifiedHours(IEnumerable<int> hours)
        {
            base.AtSpecifiedHours(hours);
            return this;
        }

        /// <summary>
        /// Every n hour(s) between some hours e.g. every 2 hour(s) between hour 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        IHourExpressionBuilder IHourExpressionBuilder.EveryNHours([Range(0, 23)] int start, [Range(0, 23)] int end,
            [Range(1, 23)] int interval)
        {
            base.EveryNHours(start, end, interval);
            return this;
        }

        /// <summary>
        /// Between hours of the specified/every day(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        IHourExpressionBuilder IHourExpressionBuilder.BetweenHours([Range(0, 23)] int start, [Range(0, 23)] int end)
        {
            base.BetweenHours(start, end);
            return this;
        }
    }
}