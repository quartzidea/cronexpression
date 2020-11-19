using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface IMinutesExpressionBuilder
    {
        IMinutesExpressionBuilder AtSpecifiedMinutes(IEnumerable<int> minutes);
        IMinutesExpressionBuilder BetweenMinutes([Range(0, 59)] int start, [Range(0, 59)] int end);
        IMinutesExpressionBuilder EveryMinute();
        IMinutesExpressionBuilder EveryNMinutes([Range(0, 59)] int startingAtMinute, [Range(1, 59)] int interval);
        IMinutesExpressionBuilder EveryNMinutes([Range(0, 59)] int start, [Range(0, 59)] int end, [Range(1, 59)] int interval);
    }
}