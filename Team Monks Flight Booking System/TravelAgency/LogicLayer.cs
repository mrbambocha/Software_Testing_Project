using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Monks_Flight_Booking_System.DatabaseInteraction.DataLayer;

namespace Team_Monks_Flight_Booking_System.TravelAgency
{
    public class LogicLayer
    {
        public DatabaseInteraction.DataLayer.ticketdbEntities entities = new DatabaseInteraction.DataLayer.ticketdbEntities();

        public void AddTicketInformation(int NumTickets, string ReceiverID, string SenderID, string totalAmountCharged, string UnitPrice)
        {
            entities.TicketBookingInfoes.Add(new DatabaseInteraction.DataLayer.TicketBookingInfo
            {
                NumberOfTickets = NumTickets,
                ReceiverID = ReceiverID,
                SenderID = SenderID,
                TotalAmountCharged = totalAmountCharged.ToString(),
                UnitPrice = UnitPrice.ToString()
            });
            entities.SaveChanges();
        }
    }
}
