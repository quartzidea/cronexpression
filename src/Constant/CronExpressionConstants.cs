using System;

namespace Schedule.CronExpressionBuilder.Constant
{
    public static class CronExpressionConstants
    {
        #region seconds

        public static class Seconds
        {
            public const string EverySecond = "* * * ? * *";
            public const string Every2Seconds = "0/2 * * ? * *";
            public const string Every3Seconds = "0/3 * * ? * *";
            public const string Every4Seconds = "0/4 * * ? * *";
            public const string Every5Seconds = "0/5 * * ? * *";
            public const string Every10Seconds = "0/10 * * ? * *";
            public const string Every15Seconds = "0/15 * * ? * *";
            public const string Every20Seconds = "0/20 * * ? * *";
            public const string Every25Seconds = "0/25 * * ? * *";
            public const string Every30Seconds = "0/30 * * ? * *";
        }

        #endregion

        #region minutes

        public static class Minutes
        {
            public const string EveryMinute = "0 * * ? * *";
            public const string Every2Minutes = "0 0/2 * ? * *";
            public const string Every3Minutes = "0 0/3 * ? * *";
            public const string Every4Minutes = "0 0/4 * ? * *";
            public const string Every5Minutes = "0 0/5 * ? * *";
            public const string Every10Minutes = "0 0/10 * ? * *";
            public const string Every15Minutes = "0 0/15 * ? * *";
            public const string Every20Minutes = "0 0/20 * ? * *";
            public const string Every25Minutes = "0 0/25 * ? * *";
            public const string Every30Minutes = "0 0/30 * ? * *";
            public const string EveryEvenMinute = "0 */2 * ? * *";
            public const string EveryUnEvenMinute = "0 1/2 * ? * *";
        }

        #endregion

        #region hours

        public static class Hours
        {
            public const string EveryHour = "0 0 * ? * *";
            public const string Every2Hours = "0 0 0/2 ? * *";
            public const string Every3Hours = "0 0 0/3 ? * *";
            public const string Every4Hours = "0 0 0/4 ? * *";
            public const string Every6Hours = "0 0 0/6 ? * *";
            public const string Every12Hours = "0 0 0/12 ? * *";
            public const string EveryEvenHours = "0 0 0/2 ? * *";
            public const string EveryUnEvenHours = "0 0 1/2 ? * *";
        }

        #endregion

        #region day

        public static class Days
        {
            public const string EveryDayAtMidNight = "0 0 0 * * ?";
            public const string EveryDayAtNoon = "0 0 12 * * ?";
            public const string EverySundayAtMidNight = "0 0 0 * * SUN";
            public const string EverySundayAtNoon = "0 0 12 * * SUN";
            public const string EveryMondayAtMidNight = "0 0 0 * * MON";
            public const string EveryMondayAtNoon = "0 0 12 * * MON";
            public const string EveryTuesdayAtMidNight = "0 0 0 * * TUE";
            public const string EveryTuesdayAtNoon = "0 0 12 * * TUE";
            public const string EveryWednesdayAtMidNight = "0 0 0 * * WED";
            public const string EveryWednesdayAtMidNoon = "0 0 12 * * WED";
            public const string EveryThursdayAtMidNight = "0 0 0 * * THU";
            public const string EveryThursdayAtNoon = "0 0 12 * * THI";
            public const string EveryFridayAtMidNight = "0 0 0 * * FRI";
            public const string EveryFridayAtNoon = "0 0 12 * * FRI";
            public const string EverySaturdayAtMidNight = "0 0 0 * * SAT";
            public const string EverySaturdayAtMidNoon = "0 0 12 * * SAT";
            public const string EveryWeekDayAtMidNight = "0 0 0 * * MON-FRI";
            public const string EveryWeekDayAtMidNoon = "0 0 12 * * MON-FRI";
            public const string EveryWeekEndsAtMidNight = "0 0 0 * * SAT,SUN";
            public const string EveryWeekEndsAtMidNoon = "0 0 12 * * SAT,SUN";
        }

        #endregion
    }
}

