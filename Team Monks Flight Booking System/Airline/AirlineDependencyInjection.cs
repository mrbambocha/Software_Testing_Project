using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Monks_Flight_Booking_System.Airline
{
    class AirlineDependencyInjection
    {
        private IAirline _iAirline;
        public AirlineDependencyInjection(IAirline _iAirline)
        {
            this._iAirline = _iAirline;
        }
        public void runAirline()
        {
            _iAirline.runAirline();
        }

        public double getPriceFromPricingModel()
        {
            return _iAirline.getPriceFromPricingModel();
        }
        public int changePrice(double previousPrice, double newPrice, string threadName, int priceCutCounter)
        {
            return _iAirline.changePrice(previousPrice, newPrice, threadName, priceCutCounter);
        }
    }
}
