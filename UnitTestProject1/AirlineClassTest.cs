using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Monks_Flight_Booking_System.Airline;

namespace UnitTestProject1
{
    [TestClass]
    public class AirlineClassTest
    {
        [TestMethod]
        public void GetPriceFromPricingModelTest()
        {
            AirlineClass airlineClass = new AirlineClass(null);
            var priceReturned = airlineClass.getPriceFromPricingModel();
            Assert.IsInstanceOfType(priceReturned, typeof(double));
        }

        [TestMethod]
        public void CheckSubscribersTest()
        {
            AirlineClass airlineClass = new AirlineClass(null);
            int priceCutCounter = airlineClass.changePrice(100, 50, "Airline 1", 0);
            Assert.AreEqual(0, priceCutCounter);
        }
    }
}
