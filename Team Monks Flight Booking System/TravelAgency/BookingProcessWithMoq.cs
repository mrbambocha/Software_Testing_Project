using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Monks_Flight_Booking_System.TravelAgency
{
    public class BookingProcessWithMoq
    {
        public int GetTicketInformation(ILogicLayer dbContext, int ticketID)
        {
            return dbContext.getTicketInformation(ticketID);
        }
    }
}
