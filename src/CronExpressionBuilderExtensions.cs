using Schedule.CronExpressionBuilder.Interface;
using System;

namespace Schedule.CronExpressionBuilder
{
    public static class CronExpressionBuilderExtensions
    {
        private const String StarWildCharacter = "*";
        private const String QWildCharacter = "?";
        private const String LastCharacter = "L";
        private const String LastCharactersc = "l";
        private const String WeekdayCharacter = "W";
        private const String WeekdayCharactersc = "w";
        private const String WeekdayNumberCharacter = "#";

        #region CronosExpressionBuilder ext

        public static ICronExpressionBuilder ConcatenateSecondExpressions(this ICronExpressionBuilder firstExpressionBuilder, Func<ICronExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[0];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of second expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[0];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of second expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[0] = firstExpression;
            return firstExpressionBuilder;
        }
        public static ICronExpressionBuilder ConcatenateMinuteExpressions(this ICronExpressionBuilder firstExpressionBuilder, Func<ICronExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[1];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of minute expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[1];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of minute expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[1] = firstExpression;
            return firstExpressionBuilder;
        }
        public static ICronExpressionBuilder ConcatenateHourExpressions(this ICronExpressionBuilder firstExpressionBuilder, Func<ICronExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[2];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of hour expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[2];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of hour expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[2] = firstExpression;
            return firstExpressionBuilder;
        }
        public static ICronExpressionBuilder ConcatenateDayOMonthExpressions(this ICronExpressionBuilder firstExpressionBuilder, Func<ICronExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[3];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter) || firstExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(WeekdayCharacter, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(WeekdayCharactersc, StringComparison.Ordinal) >= 0)
            {
                throw new InvalidOperationException("Invalid concatenation of 'day of month' expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[3];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter) || secondExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(WeekdayCharacter, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(WeekdayCharactersc, StringComparison.Ordinal) >= 0)
                {
                    throw new InvalidOperationException("Invalid concatenation of 'day of month' expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[3] = firstExpression;
            return firstExpressionBuilder;
        }
        public static ICronExpressionBuilder ConcatenateMonthExpressions(this ICronExpressionBuilder firstExpressionBuilder, Func<ICronExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[4];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of month expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[4];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of month expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[4] = firstExpression;
            return firstExpressionBuilder;
        }
        public static ICronExpressionBuilder ConcatenateDayOfWeekExpressions(this ICronExpressionBuilder firstExpressionBuilder, Func<ICronExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[5];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter) || firstExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(WeekdayNumberCharacter, StringComparison.Ordinal) >= 0)
            {
                throw new InvalidOperationException("Invalid concatenation of 'day of week' expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[5];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter) || secondExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(WeekdayNumberCharacter, StringComparison.Ordinal) >= 0)
                {
                    throw new InvalidOperationException("Invalid concatenation of 'day of week' expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[5] = firstExpression;
            return firstExpressionBuilder;
        }

        #endregion

        #region ScheduleExpressionBuilder ext

        public static ISecondsExpressionBuilder ConcatenateExpressions(this ISecondsExpressionBuilder firstExpressionBuilder, Func<ISecondsExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[0];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of second expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[0];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of second expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[0] = firstExpression;
            return firstExpressionBuilder;
        }
        public static IMinutesExpressionBuilder ConcatenateExpressions(this IMinutesExpressionBuilder firstExpressionBuilder, Func<IMinutesExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[1];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of minute expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[1];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of minute expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[1] = firstExpression;
            return firstExpressionBuilder;
        }
        public static IHourExpressionBuilder ConcatenateExpressions(this IHourExpressionBuilder firstExpressionBuilder, Func<IHourExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[2];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of hour expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[2];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of hour expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[2] = firstExpression;
            return firstExpressionBuilder;
        }
        public static IDaysOfMonthExpressionBuilder ConcatenateExpressions(this IDaysOfMonthExpressionBuilder firstExpressionBuilder, Func<IDaysOfMonthExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[3];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter) || firstExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >=0 || firstExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(WeekdayCharacter, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(WeekdayCharactersc, StringComparison.Ordinal) >= 0)
            {
                throw new InvalidOperationException("Invalid concatenation of 'day of month' expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[3];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter) || secondExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(WeekdayCharacter, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(WeekdayCharactersc, StringComparison.Ordinal) >= 0)
                {
                    throw new InvalidOperationException("Invalid concatenation of 'day of month' expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[3] = firstExpression;
            return firstExpressionBuilder;
        }
        public static IMonthsExpressionBuilder ConcatenateExpressions(this IMonthsExpressionBuilder firstExpressionBuilder, Func<IMonthsExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[4];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter))
            {
                throw new InvalidOperationException("Invalid concatenation of month expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[4];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter))
                {
                    throw new InvalidOperationException("Invalid concatenation of month expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[4] = firstExpression;
            return firstExpressionBuilder;
        }
        public static IDaysOfWeekExpressionBuilder ConcatenateExpressions(this IDaysOfWeekExpressionBuilder firstExpressionBuilder, Func<IDaysOfWeekExpressionBuilder> secondExpressionBuilderFunc)
        {
            if (firstExpressionBuilder == null)
            {
                throw new ArgumentNullException(nameof(firstExpressionBuilder));
            }

            var firstExpression = ((ICronosExpression)firstExpressionBuilder).Expressions[5];

            if (firstExpression.Equals(StarWildCharacter) || firstExpression.Equals(QWildCharacter) || firstExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || firstExpression.IndexOf(WeekdayNumberCharacter, StringComparison.Ordinal) >= 0)
            {
                throw new InvalidOperationException("Invalid concatenation of 'day of week' expressions.");
            }

            var secondexpressionBuilder = secondExpressionBuilderFunc();

            if (secondexpressionBuilder != null)
            {
                var secondExpression = ((ICronosExpression)secondexpressionBuilder).Expressions[5];

                if (secondExpression.Equals(StarWildCharacter) || secondExpression.Equals(QWildCharacter) || secondExpression.IndexOf(LastCharacter, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(LastCharactersc, StringComparison.Ordinal) >= 0 || secondExpression.IndexOf(WeekdayNumberCharacter, StringComparison.Ordinal) >= 0)
                {
                    throw new InvalidOperationException("Invalid concatenation of 'day of week' expressions.");
                }

                if (!String.IsNullOrWhiteSpace(secondExpression))
                {
                    firstExpression = (String.IsNullOrWhiteSpace(firstExpression) ? "" : firstExpression + ",") + secondExpression;
                }
            }

            ((ICronosExpression)firstExpressionBuilder).Expressions[5] = firstExpression;
            return firstExpressionBuilder;
        }

        #endregion

    }
}