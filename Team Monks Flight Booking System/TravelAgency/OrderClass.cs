using System;

namespace Team_Monks_Flight_Booking_System.TravelAgency
{
    // It represents the order object sent from travel agencies to airlines
    public class OrderClass
    {
        public string SenderId { get; set; }

        public int CardNo { get; set; }

        public string ReceiverID { get; set; }

        public int NumTickets { get; set; }

        public double UnitPrice { get; set; }
    }
}
