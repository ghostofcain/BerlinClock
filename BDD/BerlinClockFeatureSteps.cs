using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter _berlinClock = new TimeConverter((hour, minute, second) => new BerlinClockImpl(hour, minute, second));
        private string theTime;


        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(_berlinClock.ConvertTime(theTime), theExpectedBerlinClockOutput);
        }

        [Then(@"it should throw an exception")]
        public void ThenItShouldThrowAnException()
        {
            try
            {
                _berlinClock.ConvertTime(theTime);
                Assert.Fail("This line should not be hit");
            }
            catch (ArgumentException)
            {
                // ignored
            }
        }
    }
}
