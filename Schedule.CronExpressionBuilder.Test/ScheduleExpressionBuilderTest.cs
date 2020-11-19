using NUnit.Framework;
using Schedule.CronExpressionBuilder.Interface;
using System;
using System.Collections.Generic;
using CronExpressionDescriptor;
using Schedule.CronExpressionBuilder.Constant;

namespace Schedule.CronExpressionBuilder.Test
{
    [TestFixture]
    public class ScheduleExpressionBuilderTest
    {

        [SetUp]
        public void SetUp()
        {
            //To do
        }

        [TearDown]
        public void TearDown()
        {
            // To do
        }

        [Test]
        public void When_Going_With_Default_Expression()
        {
            //Arrange
            var description = CronExpressionBuilder.GetDescription(CronExpressionConstants.Seconds.EverySecond);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expression = expressionBuilder.Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert                    
            Assert.AreEqual(description, expectedDescription);
        }

        [Test]
        public void When_Building_Every_Second_Expression()
        {
            //Arrange
            var description = CronExpressionBuilder.GetDescription(CronExpressionConstants.Seconds.EverySecond);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.EverySecond()).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(CronExpressionConstants.Seconds.EverySecond);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(CronExpressionConstants.Seconds.EverySecond, expectedExpression);
        }


        [Test]
        public void When_Building_Every_Minute_Expression()
        {
            //Arrange
            var description = CronExpressionBuilder.GetDescription(CronExpressionConstants.Minutes.EveryMinute);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.AtSpecifiedSeconds(new List<Int32>() { 0 })).Minutes(min => min.EveryMinute()).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(CronExpressionConstants.Minutes.EveryMinute);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(CronExpressionConstants.Minutes.EveryMinute, expectedExpression);
        }


        [Test]
        public void When_Building_Every_Minute_At_Second_30_Expression()
        {
            //Arrange
            var description = CronExpressionBuilder.GetDescription(CronExpressionConstants.Seconds.Every30Seconds);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.EveryNSeconds(0, 30)).Minutes(min => min.EveryMinute()).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(CronExpressionConstants.Seconds.Every30Seconds);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(CronExpressionConstants.Seconds.Every30Seconds, expectedExpression);
        }

        [Test]
        public void When_building_every_25_second_past_a_minute_expression()
        {
            //Arrange
            var expression = "25 * * ? * *";
            var description = CronExpressionBuilder.GetDescription(expression);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.AtSpecifiedSeconds(new List<Int32>() { 25 })).Minutes(min => min.EveryMinute()).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_25_second_past_a_minute_and_between_minute_10_15_past_every_hour_expression()
        {
            //Arrange
            var expression = "25 10-15 * ? * *";
            var description = CronExpressionBuilder.GetDescription("25 10-15 * ? * *");

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.AtSpecifiedSeconds(new List<Int32>() { 25 }))
                .Minutes(min => min.BetweenMinutes(10, 15))
                .Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_25_second_past_minute_every_day_between_0010am_and_0015am_expression()
        {
            //Arrange
            var expression = "25 10-15 0 ? * *";
            var description = CronExpressionBuilder.GetDescription(expression);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.AtSpecifiedSeconds(new List<Int32>() { 25 }))
                .Minutes(min => min.BetweenMinutes(10, 15))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_2second_between_10and40_every_day_between_0010am_and_0015am_expression()
        {
            //Arrange
            var expression = "10-40/2 10-15 0 ? * *";
            var description = CronExpressionBuilder.GetDescription("10-40/2 10-15 0 ? * *");

            //Act

            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.EveryNSeconds(10, 40, 2))
                .Minutes(min => min.BetweenMinutes(10, 15))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_2second_between_10and40_on_last_day_between_0010am_and_0015am_expression()
        {
            //Arrange
            var expression = "10-40/2 10-15 0 L * ?";
            var description = CronExpressionBuilder.GetDescription(expression);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.EveryNSeconds(10, 40, 2))
                .Minutes(min => min.BetweenMinutes(10, 15))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .DaysOfMonth(dm => dm.LastDayOfMonth())
                .Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_2second_between_10and40_on_last_weekday_between_0010am_and_0015am_expression()
        {
            //Arrange
            var expression = "10-40/2 10-15 0 LW * ?";
            var description = CronExpressionBuilder.GetDescription(expression);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(10, 40, 2))
                .Minutes(min => min.BetweenMinutes(10, 15))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .DaysOfMonth(dm => dm.LastWeekDayOfMonth()).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_2second_between_10and40_on_last_weekday_of_jan_between_0010am_and_0020am_expression()
        {
            //Arrange
            var expression = "10-40/2 10-20 0 LW JAN ?";
            var description = CronExpressionBuilder.GetDescription("10-40/2 10-20 0 LW JAN *");

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(10, 40, 2))
                .Minutes(min => min.BetweenMinutes(10, 20))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .DaysOfMonth(dm => dm.LastWeekDayOfMonth())
                .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }


        [Test]
        public void When_building_every_10second_every_2minutes_past_hour_every_2hours_on_third_monday_between_jan_and_august_expression()
        {
            //Arrange
            var expression = "0/10 1/2 0/2 ? 1-8 2#3";
            var description = CronExpressionBuilder.GetDescription(expression);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(0, 10))
                .Minutes(min => min.EveryNMinutes(1, 2))
                .Hours(h => h.EveryNHours(0, 2))
                .DaysOfWeek(dw => dw.NthDayOfWeekOfAMonth(DayOfWeek.Monday, 3))
                .Months(m => m.BetweenMonths(MonthOfYear.January, MonthOfYear.August)).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_10second_every_2minutes_past_hour_every_2hours_on_third_monday_of_Jan_expression()
        {

            //Arrange
            var expression = "0/10 1/2 0/2 ? JAN 2#3";
            var description = CronExpressionBuilder.GetDescription(expression);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(0, 10))
                .Minutes(min => min.EveryNMinutes(1, 2))
                .Hours(h => h.EveryNHours(0, 2))
                .DaysOfWeek(dw => dw.NthDayOfWeekOfAMonth(DayOfWeek.Monday, 3))
                .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_10second_every_2minutes_past_hour_every_2hours_on_weekday_closeto15_every_2months_from_april_expression()
        {

            //Arrange
            var expression = "0/10 1/2 0/2 15W 4/2 ?";
            var description = CronExpressionBuilder.GetDescription(expression);

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(0, 10))
                .Minutes(min => min.EveryNMinutes(1, 2))
                .Hours(h => h.EveryNHours(0, 2))
                .DaysOfMonth(dm => dm.WeekDayClosestToADate(15))
                .Months(m => m.EveryNMonths(MonthOfYear.April, 2)).Build();
            var expectedDescription = CronExpressionBuilder.GetDescription(expression);

            //Assert            
            Assert.AreEqual(description, expectedDescription);
            Assert.AreEqual(expression, expectedExpression);
        }

        //Removing description from now onwards as it's becoming bit awkward

        [Test]
        public void When_building_every_2second_between_10and40_on_lastbut1_day_of_jan_between_0010am_and_0020am_expression()
        {
            //Arrange
            var expression = "10-40/2 10-20 0 L-1 JAN ?";

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(10, 40, 2))
                .Minutes(min => min.BetweenMinutes(10, 20))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .DaysOfMonth(dm => dm.NDaysBeforeLastDayOfMonth(1))
                .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();

            //Assert            
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_building_every_2second_between_10and40_on_lastbut1weekday_of_jan_between_0010am_and_0020am_expression()
        {
            //Arrange
            var expression = "10-40/2 10-20 0 L-1W JAN ?";

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder.Seconds(sec => sec.EveryNSeconds(10, 40, 2))
                .Minutes(min => min.BetweenMinutes(10, 20))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .DaysOfMonth(dm => dm.NWeekdaysBeforeLastDayOfMonth(1))
                .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January }))
                .Build();

            //Assert            
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void
            When_building_every_2second_between_10and40_and_at_second45_50_55_on_lastbut1weekday_of_jan_between_0010am_and_0020am_expression()
        {
            //Arrange
            var expression = "10-40/2,45,50,55 10-20 0 L-1W JAN ?";

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(10, 40, 2).ConcatenateExpressions(() => (new SecondsExpressionBuilder() as ISecondsExpressionBuilder).AtSpecifiedSeconds(new List<Int32>() { 45, 50, 55 })))
                .Minutes(min => min.BetweenMinutes(10, 20))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .DaysOfMonth(dm => dm.NWeekdaysBeforeLastDayOfMonth(1))
                .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();

            //Assert            
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void
            When_building_every_2second_between_10and40_and_at_second45_50_55_on_lastbut1weekday_of_jan_between_0010am_and_0020am_and_0025am_expression()
        {
            //Arrange
            var expression = "10-40/2,45,50,55 10-20,25 0 L-1W JAN ?";

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            var expectedExpression = expressionBuilder
                .Seconds(sec => sec.EveryNSeconds(10, 40, 2).ConcatenateExpressions(() => (new SecondsExpressionBuilder() as ISecondsExpressionBuilder).AtSpecifiedSeconds(new List<Int32>() { 45, 50, 55 })))
                .Minutes(min => min.BetweenMinutes(10, 20).ConcatenateExpressions(() => (new MinutesExpressionBuilder() as IMinutesExpressionBuilder).AtSpecifiedMinutes(new List<Int32>() { 25 })))
                .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                .DaysOfMonth(dm => dm.NWeekdaysBeforeLastDayOfMonth(1))
                .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();

            //Assert            
            Assert.AreEqual(expression, expectedExpression);
        }

        [Test]
        public void When_concatenating_dayofmonth_expression_having_LW()
        {
            //Arrange
            //creating expression "10-40/2,45,50,55 10-20,25 0 L-1W,10,12,14 JAN ?";

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            Assert.Throws<InvalidOperationException>(() =>
            {
                var expectedExpression = expressionBuilder
                    .Seconds(sec => sec.EveryNSeconds(10, 40, 2).ConcatenateExpressions(() => (new SecondsExpressionBuilder() as ISecondsExpressionBuilder).AtSpecifiedSeconds(new List<Int32>() { 45, 50, 55 })))
                    .Minutes(min => min.BetweenMinutes(10, 20).ConcatenateExpressions(() => (new MinutesExpressionBuilder() as IMinutesExpressionBuilder).AtSpecifiedMinutes(new List<Int32>() { 25 })))
                    .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                    .DaysOfMonth(dm => dm.NWeekdaysBeforeLastDayOfMonth(1).ConcatenateExpressions(() => (new DaysOfMonthExpressionBuilder() as IDaysOfMonthExpressionBuilder).AtSpecifiedDaysOfMonth(new List<Int32>() { 10, 12, 14 })))
                    .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();
            });

            //Assert
        }

        [Test]
        public void When_concatenating_dayofweek_expression_having_L()
        {
            //Arrange
            //creating expression "10-40/2,45,50,55 10-20,25 0 * JAN 1L,4,5 ";

            //Act
            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            Assert.Throws<InvalidOperationException>(() =>
            {
                var expectedExpression = expressionBuilder
                    .Seconds(sec => sec.EveryNSeconds(10, 40, 2).ConcatenateExpressions(() => (new SecondsExpressionBuilder() as ISecondsExpressionBuilder).AtSpecifiedSeconds(new List<Int32>() { 45, 50, 55 })))
                    .Minutes(min => min.BetweenMinutes(10, 20).ConcatenateExpressions(() => (new MinutesExpressionBuilder() as IMinutesExpressionBuilder).AtSpecifiedMinutes(new List<Int32>() { 25 })))
                    .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                    .DaysOfWeek(dow => dow.LastSpecfiedDayOfWeekOfAMonth(DayOfWeek.Sunday).ConcatenateExpressions(() => (new DaysOfWeekExpressionBuilder() as IDaysOfWeekExpressionBuilder).AtSpecifiedDaysOfWeek(new List<DayOfWeek>() { DayOfWeek.Wednesday, DayOfWeek.Thursday })))
                    .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();
            });
            //Assert
        }

        [Test]
        public void When_concatenating_dayofweek_expression_having_hashtag()
        {
            //Arrange
            //creating expression "10-40/2,45,50,55 10-20,25 0 * JAN 1#3,4,5 ";

            //Act

            IScheduleExpressionBuilder expressionBuilder = new ScheduleExpressionBuilder();
            Assert.Throws<InvalidOperationException>(() =>
            {
                var expectedExpression = expressionBuilder
                    .Seconds(sec => sec.EveryNSeconds(10, 40, 2).ConcatenateExpressions(() => (new SecondsExpressionBuilder() as ISecondsExpressionBuilder).AtSpecifiedSeconds(new List<Int32>() { 45, 50, 55 })))
                    .Minutes(min => min.BetweenMinutes(10, 20).ConcatenateExpressions(() => (new MinutesExpressionBuilder() as IMinutesExpressionBuilder).AtSpecifiedMinutes(new List<Int32>() { 25 })))
                    .Hours(h => h.AtSpecifiedHours(new List<Int32>() { 0 }))
                    .DaysOfWeek(dow => dow.NthDayOfWeekOfAMonth(DayOfWeek.Sunday, 3).ConcatenateExpressions(() => (new DaysOfWeekExpressionBuilder() as IDaysOfWeekExpressionBuilder).AtSpecifiedDaysOfWeek(new List<DayOfWeek>() { DayOfWeek.Wednesday, DayOfWeek.Thursday })))
                    .Months(m => m.AtSpecifiedMonths(new List<MonthOfYear>() { MonthOfYear.January })).Build();
            });

            //Assert
        }
    }
}