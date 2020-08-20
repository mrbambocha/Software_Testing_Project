using System;
using System.Data.Entity.Core;

namespace Team_Monks_Flight_Booking_System.TravelAgency
{
    // prints the confirmed orders received from airlines
    class ConfirmationBufferClass
    {
        private object confirmBufferLock = new object();
        // Event handler for order confirmation event
        public void orderConfirmationEventHandler(OrderClass confirmedOrder, double totalAmountCharged)
        {
            lock (confirmBufferLock)
            {
                Console.WriteLine("-------------Successfully Placed Follwoing Order------------- :\n\n");
                Console.WriteLine("Agency           :" + confirmedOrder.SenderId);
                Console.WriteLine("AirLine          :" + confirmedOrder.ReceiverID);
                Console.WriteLine("Number Of Tickets:" + confirmedOrder.NumTickets);
                Console.WriteLine("Unit Price       :" + confirmedOrder.UnitPrice);
                Console.WriteLine("Total Price      :" + totalAmountCharged + "\n\n");

                new LogicLayer().AddTicketInformation(confirmedOrder.NumTickets, confirmedOrder.ReceiverID, confirmedOrder.SenderId, totalAmountCharged.ToString(), confirmedOrder.UnitPrice.ToString());
            }
        }
    }
}
