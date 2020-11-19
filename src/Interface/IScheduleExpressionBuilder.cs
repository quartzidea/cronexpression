using System;

namespace Schedule.CronExpressionBuilder.Interface
{
    public interface IScheduleExpressionBuilder :  IExpressionBuilder, ICronosExpression
    {
        ISecondsExpressionCreated Seconds(Action<ISecondsExpressionBuilder> secondsExpressionAction);
        IMinutesExpressionCreated Minutes(Action<IMinutesExpressionBuilder> minutesExpressionAction);
        IHoursExpressionCreated Hours(Action<IHourExpressionBuilder> hoursExpressionAction);
        IDaysOfMonthExpressionCreated DaysOfMonth(Action<IDaysOfMonthExpressionBuilder> daysOfMonthExpressionAction);
        IDaysOfWeekExpressionCreated DaysOfWeek(Action<IDaysOfWeekExpressionBuilder> daysOfWeekExpressionAction);
        IMonthsExpressionCreated Months(Action<IMonthsExpressionBuilder> monthsExpressionAction);
    }

    public interface ISecondsExpressionCreated : IExpressionBuilder, ICronosExpression
    {

        IMinutesExpressionCreated Minutes(Action<IMinutesExpressionBuilder> minutesExpressionAction);
        IHoursExpressionCreated Hours(Action<IHourExpressionBuilder> hoursExpressionAction);
        IDaysOfMonthExpressionCreated DaysOfMonth(Action<IDaysOfMonthExpressionBuilder> daysOfMonthExpressionAction);
        IDaysOfWeekExpressionCreated DaysOfWeek(Action<IDaysOfWeekExpressionBuilder> daysOfWeekExpressionAction);
        IMonthsExpressionCreated Months(Action<IMonthsExpressionBuilder> monthsExpressionAction);
    }

    public interface IMinutesExpressionCreated : IExpressionBuilder, ICronosExpression
    {
        IHoursExpressionCreated Hours(Action<IHourExpressionBuilder> hoursExpressionAction);
        IDaysOfMonthExpressionCreated DaysOfMonth(Action<IDaysOfMonthExpressionBuilder> daysOfMonthExpressionAction);
        IDaysOfWeekExpressionCreated DaysOfWeek(Action<IDaysOfWeekExpressionBuilder> daysOfWeekExpressionAction);
        IMonthsExpressionCreated Months(Action<IMonthsExpressionBuilder> monthsExpressionAction);
    }

    public interface IHoursExpressionCreated : IExpressionBuilder, ICronosExpression
    {
        IDaysOfMonthExpressionCreated DaysOfMonth(Action<IDaysOfMonthExpressionBuilder> daysOfMonthExpressionAction);
        IDaysOfWeekExpressionCreated DaysOfWeek(Action<IDaysOfWeekExpressionBuilder> daysOfWeekExpressionAction);
        IMonthsExpressionCreated Months(Action<IMonthsExpressionBuilder> monthsExpressionAction);
    }

    public interface IDaysOfMonthExpressionCreated : IExpressionBuilder, ICronosExpression
    {
        IDaysOfWeekExpressionCreated DaysOfWeek(Action<IDaysOfWeekExpressionBuilder> daysOfWeekExpressionAction);
        IMonthsExpressionCreated Months(Action<IMonthsExpressionBuilder> monthsExpressionAction);
    }

    public interface IDaysOfWeekExpressionCreated : IExpressionBuilder, ICronosExpression
    {
        IMonthsExpressionCreated Months(Action<IMonthsExpressionBuilder> monthsExpressionAction);
    }

    public interface IMonthsExpressionCreated : IExpressionBuilder, ICronosExpression
    {

    }
}