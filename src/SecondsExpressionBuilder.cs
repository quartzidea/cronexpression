using Schedule.CronExpressionBuilder.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder
{
    public class SecondsExpressionBuilder : CronExpressionBuilder, ISecondsExpressionBuilder
    {
        /// <summary>
        /// expression for every second - *
        /// </summary>
        /// <returns></returns>
        ISecondsExpressionBuilder ISecondsExpressionBuilder.EverySecond()
        {
            base.EverySecond();
            return this;
        }

        /// <summary>
        /// Every n second(s) starting at some second e.g. every 2 second(s) interval starting at second 10 - 10/2 - 10,12,14,16....
        /// </summary>
        /// <returns></returns>
        ISecondsExpressionBuilder ISecondsExpressionBuilder.EveryNSeconds([Range(0, 59)] int startingAtSecond, [Range(1, 59)] int interval)
        {
            base.EveryNSeconds(startingAtSecond, interval);
            return this;
        }


        /// <summary>
        /// At specified seconds between 0 to 59 of specified/every minute - 0,2,4,5
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        ISecondsExpressionBuilder ISecondsExpressionBuilder.AtSpecifiedSeconds(IEnumerable<int> seconds)
        {
            base.AtSpecifiedSeconds(seconds);
            return this;
        }

        /// <summary>
        ///  Every n second(s) between some seconds e.g. every 2 second(s) between second 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        ISecondsExpressionBuilder ISecondsExpressionBuilder.EveryNSeconds([Range(00, 59)] int start, [Range(0, 59)] int end, [Range(1, 59)] int interval)
        {
            base.EveryNSeconds(start, end, interval);
            return this;
        }

        /// <summary>
        /// Between minutes of the specified/every hour(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        ISecondsExpressionBuilder ISecondsExpressionBuilder.BetweenSeconds([Range(0, 59)] int start, [Range(0, 59)] int end)
        {
            base.BetweenSeconds(start, end);
            return this;
        }
    }
}