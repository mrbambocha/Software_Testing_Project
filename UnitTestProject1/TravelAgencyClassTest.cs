using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Monks_Flight_Booking_System.TravelAgency;

namespace UnitTestProject1
{
    [TestClass]
    public class TravelAgencyClassTest
    {
        [TestMethod]
        public void CalculateNumberOfTicketsTestForDefault()
        {
            int numberOfTickets = 0;
            TravelAgencyClass travelAgencyClass = new TravelAgencyClass(null);
            numberOfTickets = travelAgencyClass.calculateNumberOfTickets(300.0, 250.98);
            Assert.AreEqual(5, numberOfTickets);
        }

        [TestMethod]
        public void CalculateNumberOfTicketsTestFor100To200()
        {
            int numberOfTickets = 0;
            TravelAgencyClass travelAgencyClass = new TravelAgencyClass(null);
            numberOfTickets = travelAgencyClass.calculateNumberOfTickets(300.0, 150.89);
            Assert.AreEqual(10, numberOfTickets);
        }

        [TestMethod]
        public void CalculateNumberOfTicketsTestFor200To300()
        {
            int numberOfTickets = 0;
            TravelAgencyClass travelAgencyClass = new TravelAgencyClass(null);
            numberOfTickets = travelAgencyClass.calculateNumberOfTickets(300.0, 75.0);
            Assert.AreEqual(12, numberOfTickets);
        }

        [TestMethod]
        public void CalculateNumberOfTicketsTestFor700To800()
        {
            int numberOfTickets = 0;
            TravelAgencyClass travelAgencyClass = new TravelAgencyClass(null);
            numberOfTickets = travelAgencyClass.calculateNumberOfTickets(1000, 250);
            Assert.AreEqual(25, numberOfTickets);
        }
    }
}
