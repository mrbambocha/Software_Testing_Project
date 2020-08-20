using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Monks_Flight_Booking_System.DatabaseInteraction.DataLayer;

namespace Team_Monks_Flight_Booking_System.TravelAgency
{
    public interface ILogicLayer
    {
        void AddTicketInformation(int NumTickets, string ReceiverID, string SenderID, string totalAmountCharged, string UnitPrice);
        int getTicketInformation(int instanceID);
    }
}
