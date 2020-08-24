using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Team_Monks_Flight_Booking_System;
using Team_Monks_Flight_Booking_System.TravelAgency;

namespace UnitTestMockingDatabaseConnection
{
    [TestClass]
    public class DatabaseConnTest
    {
        [TestMethod]
        public void GetItemFromDatabaseTest()
        {
            int ticketID = 1;
            Mock<ILogicLayer> mockDbContext = new Mock<ILogicLayer>();
            mockDbContext.Setup(x => x.getTicketInformation(It.IsAny<int>())).Returns(ticketID);

            BookingProcessWithMoq logicLayerProcessingWithMoq = new BookingProcessWithMoq();
            var result = logicLayerProcessingWithMoq.GetTicketInformation(mockDbContext.Object, ticketID);
            Assert.IsTrue(result
                == ticketID);

        }
    }
}
