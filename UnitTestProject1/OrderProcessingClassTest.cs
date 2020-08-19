using Team_Monks_Flight_Booking_System;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team_Monks_Flight_Booking_System.TravelAgency;
using Team_Monks_Flight_Booking_System.Airline;

namespace UnitTestProject1
{
    [TestClass]
    public class OrderProcessingClassTest
    {
        [TestMethod]
        public void IsValidCreditCardFormatTesting()
        {
            OrderClass orderObject = new OrderClass
            {
                CardNo = 5001,
                NumTickets = 1,
                ReceiverID = "1",
                SenderId = "0",
                UnitPrice = 12.95
            };
            OrderProcessingClass orderProcessing = new OrderProcessingClass(orderObject);
            Assert.IsTrue(OrderProcessingClass.isValidCreditCardFormat());
        }

        [TestMethod]
        public void IsNotValidCreditCardFormatTest()
        {
            OrderClass orderObject = new OrderClass
            {
                CardNo = 4000,
                NumTickets = 1,
                ReceiverID = "1",
                SenderId = "0",
                UnitPrice = 12.95
            };
            OrderProcessingClass orderProcessing = new OrderProcessingClass(orderObject);
            Assert.IsFalse(OrderProcessingClass.isValidCreditCardFormat());
        }

        [TestMethod]
        public void CalculateTotalAmountTest()
        {
            OrderClass orderObject = new OrderClass
            {
                CardNo = 4000,
                NumTickets = 1,
                ReceiverID = "1",
                SenderId = "0",
                UnitPrice = 10.0
            };
            OrderProcessingClass orderProcessing = new OrderProcessingClass(orderObject);
            var ticketPrice = OrderProcessingClass.calculateTotalAmount();
            //Amount- 11.17 - calculated by simple mathematics
            Assert.AreEqual(11.17, ticketPrice);
        }

        [TestMethod]
        public void runOrderProcessingTest()
        {
            OrderProcessingClass orderProcessing = new OrderProcessingClass(new OrderClass { CardNo = 5001, NumTickets = 1, ReceiverID = "1", SenderId = "2", UnitPrice = 10 });
            var flag = orderProcessing.runOrderProcessing(1);
            Assert.IsTrue(flag);
        }
    }
}
