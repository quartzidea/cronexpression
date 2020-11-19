using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface IHourExpressionBuilder
    {
        IHourExpressionBuilder AtSpecifiedHours(IEnumerable<int> hours);
        IHourExpressionBuilder BetweenHours([Range(0, 23)] int start, [Range(0, 23)] int end);
        IHourExpressionBuilder EveryHour();
        IHourExpressionBuilder EveryNHours([Range(0, 23)] int startingAtHour, [Range(1, 23)] int interval);
        IHourExpressionBuilder EveryNHours([Range(0, 23)] int start, [Range(0, 23)] int end, [Range(1, 23)] int interval);
    }
}