using System;
using System.Data.Entity.Core;

namespace Team_Monks_Flight_Booking_System.TravelAgency
{
    // prints the confirmed orders received from airlines
    class ConfirmationBufferClass
    {
        private object confirmBufferLock = new object();
        private DatabaseInteraction.DataLayer.ticketdbEntities entities = new DatabaseInteraction.DataLayer.ticketdbEntities();
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
                entities.TicketBookingInfoes.Add(new DatabaseInteraction.DataLayer.TicketBookingInfo
                {
                    NumberOfTickets = confirmedOrder.NumTickets,
                    ReceiverID = confirmedOrder.ReceiverID,
                    SenderID = confirmedOrder.SenderId,
                    TotalAmountCharged = totalAmountCharged.ToString(),
                    UnitPrice = confirmedOrder.UnitPrice.ToString()
                });
                entities.SaveChanges();
            }
        }
    }
}
