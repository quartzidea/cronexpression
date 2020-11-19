using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface ISecondsExpressionBuilder : IExpressionBuilder
    {
        ISecondsExpressionBuilder AtSpecifiedSeconds(IEnumerable<int> seconds);
        ISecondsExpressionBuilder BetweenSeconds([Range(0, 59)] int start, [Range(0, 59)] int end);
        ISecondsExpressionBuilder EveryNSeconds([Range(0, 59)] int startingAtSecond, [Range(1, 59)] int interval);
        ISecondsExpressionBuilder EveryNSeconds([Range(0, 59)] int start, [Range(0, 59)] int end, [Range(1, 59)] int interval);
        ISecondsExpressionBuilder EverySecond();
    }
}