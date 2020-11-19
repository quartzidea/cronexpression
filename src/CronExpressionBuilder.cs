using Schedule.CronExpressionBuilder.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Schedule.CronExpressionBuilder
{
    public class CronExpressionBuilder : ICronExpressionBuilder
    {
        public List<String> Expressions { get; set; } = new List<String>();

        public CronExpressionBuilder()
            : this("* * * ? * *")
        {
        }

        internal CronExpressionBuilder(String cronExpression)
        {
            if (String.IsNullOrWhiteSpace(cronExpression))
            {
                throw new ArgumentException(
                    $"{nameof(cronExpression)} is either null, empty or contains white spaces.");
            }

            var splitedExpressions = cronExpression.Split(new[] {' '}, StringSplitOptions.None);

            if (splitedExpressions.Length != 6)
            {
                throw new ArgumentException(
                    $"{nameof(cronExpression)} should have six components from seconds to Day of week.");
            }

            Expressions.AddRange(splitedExpressions);
        }



        public String Build()
        {
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

        #region Seconds

        /// <summary>
        /// expression for every second - *
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EverySecond()
        {
            Expressions[0] = "*";
            return this;
        }

        /// <summary>
        /// Every n second(s) starting at some second e.g. every 2 second(s) interval starting at second 10 - 10/2 - 10,12,14,16....
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNSeconds([Range(0, 59)] int startingAtSecond, [Range(1, 59)] int interval)
        {
            Expressions[0] = $"{startingAtSecond}/{interval}";
            return this;
        }


        /// <summary>
        /// At specified seconds between 0 to 59 of specified/every minute - 0,2,4,5
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public ICronExpressionBuilder AtSpecifiedSeconds(IEnumerable<int> seconds)
        {
            Expressions[0] = CreateSpecifiedCronExpression(seconds, 0, 59);
            return this;
        }

        /// <summary>
        ///  Every n second(s) between some seconds e.g. every 2 second(s) between second 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNSeconds([Range(00, 59)] int start, [Range(0, 59)] int end,
            [Range(1, 59)] int interval)
        {
            Expressions[0] = $"{start}-{end}/{interval}";
            return this;
        }

        /// <summary>
        /// Between minutes of the specified/every hour(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder BetweenSeconds([Range(0, 59)] int start, [Range(0, 59)] int end)
        {
            Expressions[0] = $"{start}-{end}";
            return this;
        }

        #endregion

        #region Minutes

        /// <summary>
        /// expression for every minute - *
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryMinute()
        {
            Expressions[1] = "*";
            return this;
        }

        /// <summary>
        /// Every n minute(s) starting at some minute e.g. every 2 minute(s) interval starting at minute 10 - 10/2 - 10,12,14,16....
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNMinutes([Range(0, 59)] int startingAtMinute, [Range(1, 59)] int interval)
        {
            Expressions[1] = $"{startingAtMinute}/{interval}";
            return this;
        }

        /// <summary>
        /// At specified minutes between 0 to 59 of specified/every hour - 0,2,4,5.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public ICronExpressionBuilder AtSpecifiedMinutes(IEnumerable<int> minutes)
        {
            Expressions[1] = CreateSpecifiedCronExpression(minutes, 0, 59);
            return this;
        }

        /// <summary>
        /// Every n minute(s) between some minutes e.g. every 2 minute(s) between minute 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNMinutes([Range(0, 59)] int start, [Range(0, 59)] int end,
            [Range(1, 59)] int interval)
        {
            Expressions[1] = $"{start}-{end}/{interval}";
            return this;
        }

        /// <summary>
        /// Between minutes of the specified/every hour(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder BetweenMinutes([Range(0, 59)] int start, [Range(0, 59)] int end)
        {
            Expressions[1] = $"{start}-{end}";
            return this;
        }

        #endregion

        #region Hours

        /// <summary>
        /// expression for every hour - *
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryHour()
        {
            Expressions[2] = "*";
            return this;
        }

        /// <summary>
        /// Every n hour(s) starting at some hour e.g. every 2 hour(s) starting at 08:00  - 8/2 - 8,10,12,....
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNHours([Range(0, 23)] int startingAtHour, [Range(1, 23)] int interval)
        {
            Expressions[2] = $"{startingAtHour}/{interval}";
            return this;
        }

        /// <summary>
        /// At specified hours between 0 to 23 of a specified/every day - 0,2,4,5.
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public ICronExpressionBuilder AtSpecifiedHours(IEnumerable<int> hours)
        {
            Expressions[2] = CreateSpecifiedCronExpression(hours, 0, 23);
            return this;
        }

        /// <summary>
        /// Every n hour(s) between some hours e.g. every 2 hour(s) between hour 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNHours([Range(0, 23)] int start, [Range(0, 23)] int end,
            [Range(1, 23)] int interval)
        {
            Expressions[2] = $"{start}-{end}/{interval}";
            return this;
        }

        /// <summary>
        /// Between hours of the specified/every day(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder BetweenHours([Range(0, 23)] int start, [Range(0, 23)] int end)
        {
            Expressions[2] = $"{start}-{end}";
            return this;
        }

        #endregion

        #region Day of month

        /// <summary>
        /// expression for every day - *
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryDayOfMonth()
        {
            Expressions[3] = "?";
            Expressions[5] = "*";
            return this;
        }

        /// <summary>
        /// Every n day starting at some day of a month e.g. every 3 day starting 1st day of the month
        /// </summary>
        /// <param name="startingAtDay"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNDaysOfMonth([Range(1, 31)] int startingAtDay, [Range(1, 31)] int interval)
        {
            Expressions[3] = $"{startingAtDay}/{interval}";
            return this;
        }

        /// <summary>
        /// At specified days of a month, between 1 to 31 of specified/every month - 0,2,4,5.
        /// </summary>
        /// <param name="daysOfMonth"></param>
        /// <returns></returns>
        public ICronExpressionBuilder AtSpecifiedDaysOfMonth(IEnumerable<int> daysOfMonth)
        {
            Expressions[3] = CreateSpecifiedCronExpression(daysOfMonth, 1, 31);
            return this;
        }

        /// <summary>
        /// Every n day(s) between some dates e.g. every 2 days(s) between date 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end,
            [Range(1, 31)] int interval)
        {
            Expressions[3] = $"{start}-{end}/{interval}";
            return this;
        }

        /// <summary>
        /// Last day of specified/every month.
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder LastDayOfMonth()
        {
            Expressions[3] = "L";
            return this;
        }

        /// <summary>
        /// Last week day of specified/every month.
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder LastWeekDayOfMonth()
        {
            Expressions[3] = "LW";
            return this;
        }


        /// <summary>
        /// Day before last day of specified/every month.
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder DayBeforeLastDayOfMonth()
        {
            Expressions[3] = "L-1";
            return this;
        }

        /// <summary>
        /// N weekday(s) before last day of specified/every month.
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder NWeekdaysBeforeLastDayOfMonth([Range(1, 31)] int weekdaysBeforeLastDay)
        {
            weekdaysBeforeLastDay = weekdaysBeforeLastDay * -1;
            Expressions[3] = "L" + weekdaysBeforeLastDay + "W";
            return this;
        }

        /// <summary>
        /// n day(s) before last day of specified/every month.
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder NDaysBeforeLastDayOfMonth([Range(1, 31)] int daysBeforeLastDay)
        {
            daysBeforeLastDay = daysBeforeLastDay * -1;
            Expressions[3] = "L" + daysBeforeLastDay;
            return this;
        }


        /// <summary>
        /// Week day close to a specified date of specified/every month.
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder WeekDayClosestToADate([Range(1, 31)] int dateofAMonth)
        {
            Expressions[3] = dateofAMonth + "W";
            return this;
        }

        /// <summary>
        /// Between days of the specified/every month(s) e.g. 10-14
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder BetweenDaysOfMonth([Range(1, 31)] int start, [Range(1, 31)] int end)
        {
            Expressions[3] = $"{start}-{end}";
            return this;
        }

        #endregion

        #region Day of Week

        /// <summary>
        /// Every N day(s) starting at specified day of a week e.g. 2 days starting from Monday - 2/2 - Monday, Wednesday ...
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNDaysSyartingAtDayOfWeek(DayOfWeek startAtWeekDay,[Range(1, 7)] int interval)
        {
            var startingAt = (int) startAtWeekDay + 1;
            Expressions[5] = $"{startingAt}/{interval}";
            ;
            return this;
        }


        /// <summary>
        /// Every weekdays - Monday to Friday
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder WeekDays()
        {
            Expressions[5] = "MON-FRI";
            return this;
        }

        /// <summary>
        /// Every weekends - Saturday, Sunday
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder WeekEnds()
        {
            Expressions[5] = "SAT-SUN";
            return this;
        }


        /// <summary>
        /// Every weekends - Saturday, Sunday
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder AtSpecifiedDaysOfWeek(IEnumerable<DayOfWeek> daysOfWeek)
        {
            if (daysOfWeek == null)
            {
                throw new ArgumentException($"{nameof(daysOfWeek)} is null.");
            }

            var daysOfWeekAsString = new List<string>();

            foreach (DayOfWeek dayOfWeek in daysOfWeek)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        daysOfWeekAsString.Add("SUN");
                        break;
                    case DayOfWeek.Monday:
                        daysOfWeekAsString.Add("MON");
                        break;
                    case DayOfWeek.Tuesday:
                        daysOfWeekAsString.Add("TUE");
                        break;
                    case DayOfWeek.Wednesday:
                        daysOfWeekAsString.Add("WED");
                        break;
                    case DayOfWeek.Thursday:
                        daysOfWeekAsString.Add("THU");
                        break;
                    case DayOfWeek.Friday:
                        daysOfWeekAsString.Add("FRI");
                        break;
                    case DayOfWeek.Saturday:
                        daysOfWeekAsString.Add("SAT");
                        break;
                }
            }

            if (daysOfWeekAsString.Count > 0)
            {
                Expressions[5] = String.Join(",", daysOfWeekAsString.ToArray());
            }
            return this;
        }

        /// <summary>
        /// Last specified day of week e.g. last monday of the month.
        /// </summary>
        /// <param name="lastDayOfWeekOfTheMonth"></param>
        /// <returns></returns>
        public ICronExpressionBuilder LastSpecfiedDayOfWeekOfAMonth(DayOfWeek lastDayOfWeekOfTheMonth)
        {
            var lastdayofWeekOfTheMonthAsInt = (int) lastDayOfWeekOfTheMonth + 1;
            Expressions[5] = lastdayofWeekOfTheMonthAsInt + "L";
            return this;
        }

        /// <summary>
        /// Nth day of Week of the month e.g. 2nd Monday of the Month.
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <param name="numberN"></param>
        /// <returns></returns>
        public ICronExpressionBuilder NthDayOfWeekOfAMonth(DayOfWeek dayOfWeek, [Range(1, 5)] int numberN)
        {
            var dayOfWeekAsInt = (int) dayOfWeek + 1;
            Expressions[5] = $"{dayOfWeekAsInt}#{numberN}";
            return this;
        }

        /// <summary>
        /// Between days of the week e.g. Tuesday - Friday
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder BetweenDaysOfWeek(DayOfWeek start, DayOfWeek end)
        {
            var startdayAsInt = (int) start;
            var endDayAsInt = (int) end;
            Expressions[5] = $"{startdayAsInt}-{endDayAsInt}";
            return this;
        }

        #endregion

        #region Month

        /// <summary>
        /// Every month of the year.
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryMonth()
        {
            Expressions[4] = "*";
            return this;
        }

        /// <summary>
        /// Every n month(s) starting at some month e.g. every 2 month(s) interval starting from June - 6/2 - 6,8,10,12....
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNMonths(MonthOfYear startingAtMonth, [Range(1, 12)] int interval)
        {
            var startMonthAsInt = (int) startingAtMonth;
            Expressions[4] = $"{startMonthAsInt}/{interval}";
            return this;
        }

        /// <summary>
        /// At specified minutes between 0 to 59 of specified/every hour - 0,2,4,5.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public ICronExpressionBuilder AtSpecifiedMonths(IEnumerable<MonthOfYear> months)
        {
            if (months == null)
            {
                throw new ArgumentException($"{nameof(months)} is null.");
            }

            var monthsOfYearAsString = new List<string>();

            foreach (MonthOfYear month in months)
            {
                switch (month)
                {
                    case MonthOfYear.January:
                        monthsOfYearAsString.Add("JAN");
                        break;
                    case MonthOfYear.February:
                        monthsOfYearAsString.Add("FEB");
                        break;
                    case MonthOfYear.March:
                        monthsOfYearAsString.Add("MAR");
                        break;
                    case MonthOfYear.April:
                        monthsOfYearAsString.Add("APR");
                        break;
                    case MonthOfYear.May:
                        monthsOfYearAsString.Add("MAY");
                        break;
                    case MonthOfYear.June:
                        monthsOfYearAsString.Add("JUN");
                        break;
                    case MonthOfYear.July:
                        monthsOfYearAsString.Add("JUL");
                        break;
                    case MonthOfYear.August:
                        monthsOfYearAsString.Add("AUG");
                        break;
                    case MonthOfYear.September:
                        monthsOfYearAsString.Add("SEP");
                        break;
                    case MonthOfYear.October:
                        monthsOfYearAsString.Add("OCT");
                        break;
                    case MonthOfYear.November:
                        monthsOfYearAsString.Add("NOV");
                        break;
                    case MonthOfYear.December:
                        monthsOfYearAsString.Add("DEC");
                        break;
                }
            }

            if (monthsOfYearAsString.Count > 0)
            {
                Expressions[4] = String.Join(",", monthsOfYearAsString.ToArray());
            }
            return this;
        }

        /// <summary>
        /// Every n month(s) between some months e.g. every 2 month(s) between month 5 and 10 - 5-10/2 - 5,7,9...
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder EveryNMonths(MonthOfYear start, MonthOfYear end, [Range(1, 59)] int interval)
        {
            var startMonthAsInt = (int) start;
            var endMonthAsInt = (int) end;
            Expressions[4] = $"{startMonthAsInt}-{endMonthAsInt}/{interval}";
            return this;
        }

        /// <summary>
        /// Between some months of the year e.g. Jan to May - JAN-MAY
        /// </summary>
        /// <returns></returns>
        public ICronExpressionBuilder BetweenMonths(MonthOfYear start, MonthOfYear end)
        {
            var startMonthAsInt = (int) start;
            var endMonthAsInt = (int) end;
            Expressions[4] = $"{startMonthAsInt}-{endMonthAsInt}";
            return this;
        }

        #endregion`

        public static string GetDescription(string cronExpression)
        {
            if (String.IsNullOrWhiteSpace(cronExpression))
            {
                throw new ArgumentException(
                    $"{nameof(cronExpression)} is either null, empty or contains white spaces.");
            }

            string[] expressionParts = cronExpression.Split(' ');

            if (expressionParts.Length != 6)
            {
                throw new InvalidCastException("Invalid cron expression");
            }

            return CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cronExpression);
        }

        private string CreateSpecifiedCronExpression(IEnumerable<int> numbers, int min = 0, int max = 59)
        {
            if (numbers == null)
            {
                throw new ArgumentException($"{nameof(numbers)} is null.");
            }

            var listofNumbers = numbers as IList<Int32> ?? numbers.ToList();

            if (listofNumbers.Count == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} is empty.");
            }

            listofNumbers = listofNumbers.OrderBy(x => x).ToList();
            var expression = "";

            for (int i = 0; i < listofNumbers.Count; i++)
            {
                int second = listofNumbers[i];

                if (second < 0 || second > 59)
                {
                    continue;
                }

                expression = expression + second;
                if (i < listofNumbers.Count - 1)
                {
                    expression = expression + ",";
                }
            }

            return expression;
        }
    }
}
