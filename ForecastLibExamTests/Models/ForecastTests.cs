using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForecastLibExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastLibExam.Models.Tests
{
    [TestClass()]
    public class ForecastTests
    {
        [TestMethod()]
        public void validateGoodTest()
        {
            Forecast goodForecast = new Forecast();
            goodForecast.Temperature = 20;
            goodForecast.Humidity = 50;
            goodForecast.Validate();
            Assert.IsTrue(true);


        }
        [TestMethod()]
        public void validateBadTest()
        {
            Forecast badForecast = new Forecast();
            badForecast.Temperature = 40;
            badForecast.Humidity = 120;
            Assert.ThrowsException<Exception>(() => badForecast.Validate());
        }
    }
}