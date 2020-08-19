using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Monks_Flight_Booking_System.Airline
{
    interface IAirline
    {
        void runAirline();
        double getPriceFromPricingModel();
        int changePrice(double previousPrice, double newPrice, string threadName, int priceCutCounter);
    }
}
