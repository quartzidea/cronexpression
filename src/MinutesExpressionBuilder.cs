using Schedule.CronExpressionBuilder.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder
{
    public class MinutesExpressionBuilder : CronExpressionBuilder, IMinutesExpressionBuilder
    {
        /// <summary>
        /// expression for every minute - *
        /// </summary>
        /// <returns></returns>
        IMinutesExpressionBuilder IMinutesExpressionBuilder.EveryMinute()
        {
            base.EveryMinute();
            return this;
        }

        /// <summary>
        /// Every n minute(s) starting at some minute e.g. every 2 minute(s) interval starting at minute 10 - 10/2 - 10,12,14,16....
        /// </summary>
        /// <returns></returns>
        IMinutesExpressionBuilder IMinutesExpressionBuilder.EveryNMinutes([Range(0, 59)] int startingAtMinute, [Range(1, 59)] int interval)
        {
            base.EveryNMinutes(startingAtMinute, interval);
            return this;
        }

        /// <summary>
        /// At specified minutes between 0 to 59 of specified/every hour - 0,2,4,5.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        IMinutesExpressionBuilder IMinutesExpressionBuilder.AtSpecifiedMinutes(IEnumerable<int> minutes)
        {
            base.AtSpecifiedMinutes(minutes);
            return this;
        }

        /// <summary>
        /// Every n minute(s) between some minutes e.g. every 2 minute(s) between minute 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        IMinutesExpressionBuilder IMinutesExpressionBuilder.EveryNMinutes([Range(0, 59)] int start, [Range(0, 59)] int end, [Range(1, 59)] int interval)
        {
            base.EveryNMinutes(start, end, interval);
            return this;
        }

        /// <summary>
        /// Between minutes of the specified/every hour(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        IMinutesExpressionBuilder IMinutesExpressionBuilder.BetweenMinutes([Range(0, 59)] int start, [Range(0, 59)] int end)
        {
            base.BetweenMinutes(start, end);
            return this;
        }
    }
}