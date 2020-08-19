using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team_Monks_Flight_Booking_System;
using Team_Monks_Flight_Booking_System.TravelAgency;
using Team_Monks_Flight_Booking_System.Utility;

namespace UnitTestProject1
{
    [TestClass]
    public class EncoderDecoderClassTest
    {

        [TestMethod]
        public void EncodeOrderObjectTest()
        {
            OrderClass orderObject = new OrderClass
            {
                CardNo = 1,
                NumTickets = 2,
                ReceiverID = "1",
                SenderId = "0",
                UnitPrice = 12.95
            };
            string outputOrderString = EncoderDecoderClass.encodeOrderObject(orderObject);
            Assert.IsInstanceOfType(outputOrderString, typeof(string));
        }

        [TestMethod]
        public void DecodeOrderObjectTest()
        {
            OrderClass orderObject = new OrderClass
            {
                CardNo = 1,
                NumTickets = 2,
                ReceiverID = "1",
                SenderId = "0",
                UnitPrice = 12.95
            };
            string outputOrderString = EncoderDecoderClass.encodeOrderObject(orderObject);
            var orderClass = EncoderDecoderClass.decodeOrderObject(outputOrderString);

            Assert.AreEqual(orderClass.CardNo, orderObject.CardNo);
            Assert.AreEqual(orderClass.NumTickets, orderObject.NumTickets);
            Assert.AreEqual(orderClass.ReceiverID, orderObject.ReceiverID);
            Assert.AreEqual(orderClass.SenderId, orderObject.SenderId);
            Assert.AreEqual(orderClass.UnitPrice, orderObject.UnitPrice);
        }
    }
}
