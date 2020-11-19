using System.Collections.Generic;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface ICronosExpression
    {
        List<string> Expressions { get; set; }
    }
}