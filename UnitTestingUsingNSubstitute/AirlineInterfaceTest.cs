using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using Team_Monks_Flight_Booking_System.Airline;
using Assert = NUnit.Framework.Assert;

namespace UnitTestingUsingNSubstitute
{
    [TestClass]
    public class AirlineInterfaceTest
    {
        [TestMethod]
        public void TestChangePriceUsingNSubstitue()
        {
            var airline = Substitute.For<IAirline>();
            //Telling the substitute to return a value for the call
            airline.changePrice(100, 50, "Thread 1 from NSubstitue", 0).Returns(0);
            //Testing the value
            Assert.AreEqual(airline.changePrice(100, 50, "Thread 1 from NSubstitue", 0), 0);
        }

        [TestMethod]
        public void TestGetPriceFromPricingModel()
        {
            var airline = Substitute.For<IAirline>();
            //Telling the substitue to return a value for the call
            airline.getPriceFromPricingModel().Returns<double>(new Random().Next(100, 900));
            //Testing the value
            var gettingValue = airline.getPriceFromPricingModel();
            Assert.IsTrue(gettingValue > 100 && gettingValue < 900);
        }
    }
}
