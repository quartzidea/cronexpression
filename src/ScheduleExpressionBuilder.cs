using Schedule.CronExpressionBuilder.Interface;
using System;
using System.Collections.Generic;

namespace Schedule.CronExpressionBuilder
{
    
    public class ScheduleExpressionBuilder : IScheduleExpressionBuilder, ISecondsExpressionCreated, IMinutesExpressionCreated, IHoursExpressionCreated, IDaysOfMonthExpressionCreated, IDaysOfWeekExpressionCreated,IMonthsExpressionCreated
    {
        private readonly ISecondsExpressionBuilder _secondsExpressionBuilder;
        private readonly IMinutesExpressionBuilder _minutesExpressionBuilder;
        private readonly IHourExpressionBuilder _hourExpressionBuilder;
        private readonly IDaysOfMonthExpressionBuilder _daysOfMonthExpressionBuilder;
        private readonly IDaysOfWeekExpressionBuilder _daysOfWeekExpressionBuilder;
        private readonly IMonthsExpressionBuilder _monthsExpressionBuilder;

        public ScheduleExpressionBuilder()
            : this(new SecondsExpressionBuilder(), new MinutesExpressionBuilder(), new HourExpressionBuilder(), new DaysOfMonthExpressionBuilder(), new DaysOfWeekExpressionBuilder(), new MonthsExpressionBuilder())
        {
        }
        
        public ScheduleExpressionBuilder(ISecondsExpressionBuilder secondsExpressionBuilder, IMinutesExpressionBuilder minutesExpressionBuilder, IHourExpressionBuilder hourExpressionBuilder, IDaysOfMonthExpressionBuilder daysOfMonthExpressionBuilder,IDaysOfWeekExpressionBuilder daysOfWeekExpressionBuilder, IMonthsExpressionBuilder monthsExpressionBuilder)
        {
            _secondsExpressionBuilder = secondsExpressionBuilder ?? new SecondsExpressionBuilder();
            _minutesExpressionBuilder = minutesExpressionBuilder ?? new MinutesExpressionBuilder();
            _hourExpressionBuilder = hourExpressionBuilder ?? new HourExpressionBuilder();
            _daysOfMonthExpressionBuilder = daysOfMonthExpressionBuilder ?? new DaysOfMonthExpressionBuilder();
            _daysOfWeekExpressionBuilder = daysOfWeekExpressionBuilder ?? new DaysOfWeekExpressionBuilder();
            _monthsExpressionBuilder = monthsExpressionBuilder ?? new MonthsExpressionBuilder();
            Expressions = null;
        }

        public ISecondsExpressionCreated Seconds(Action<ISecondsExpressionBuilder> secondsExpressionAction)
        {
            ValidateAndAssignExpression((ICronosExpression)_secondsExpressionBuilder);
            secondsExpressionAction(_secondsExpressionBuilder);
            return this;
        }

        public IMinutesExpressionCreated Minutes(Action<IMinutesExpressionBuilder> minutesExpressionAction)
        {
            ValidateAndAssignExpression((ICronosExpression) _minutesExpressionBuilder);
            minutesExpressionAction(_minutesExpressionBuilder);
            return this;
        }

        public IHoursExpressionCreated Hours(Action<IHourExpressionBuilder> hoursExpressionAction)
        {
            ValidateAndAssignExpression((ICronosExpression) _hourExpressionBuilder);
            hoursExpressionAction(_hourExpressionBuilder);
            return this;
        }

        public IDaysOfMonthExpressionCreated DaysOfMonth(Action<IDaysOfMonthExpressionBuilder> daysOfMonthExpressionAction)
        {
            ValidateAndAssignExpression((ICronosExpression)_daysOfMonthExpressionBuilder);
            daysOfMonthExpressionAction(_daysOfMonthExpressionBuilder);
            return this;
        }

        public IDaysOfWeekExpressionCreated DaysOfWeek(Action<IDaysOfWeekExpressionBuilder> daysOfWeekExpressionAction)
        {
            ValidateAndAssignExpression((ICronosExpression)_daysOfWeekExpressionBuilder);
            daysOfWeekExpressionAction(_daysOfWeekExpressionBuilder);
            return this;
        }

        public IMonthsExpressionCreated Months(Action<IMonthsExpressionBuilder> monthsExpressionAction)
        {
            ValidateAndAssignExpression((ICronosExpression)_monthsExpressionBuilder);
            monthsExpressionAction(_monthsExpressionBuilder);
            return this;
        }

        public String Build()
        {
            if (Expressions == null || Expressions.Count == 0)
            {
                return "* * * ? * *";
            }

            if (Expressions[3] != "*" && Expressions[3] != "?" && Expressions[5] == "*")
            {
                Expressions[5] = "?";
            }

            var expression = String.Join(" ", Expressions);

            if (String.IsNullOrWhiteSpace(expression) || Expressions.Count < 6)
            {
                throw new Exception("Invalid cron expression.");
            }

            return expression;
        }

        public List<String> Expressions { get; set; }

        private void ValidateAndAssignExpression(ICronosExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (Expressions == null)
            {
                Expressions = expression.Expressions;
            }
            else
            {
                expression.Expressions = Expressions;
            }
        }
    }
}