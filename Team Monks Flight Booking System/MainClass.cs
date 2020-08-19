using System;
using System.Threading;
using Team_Monks_Flight_Booking_System.Utility;
using Team_Monks_Flight_Booking_System.Airline;
using Team_Monks_Flight_Booking_System.TravelAgency;

namespace Team_Monks_Flight_Booking_System
{
    class MainClass
    {
        public static MultiCellBufferClass buffer = new MultiCellBufferClass();
        //Implemented the Dependency Injection
        private static AirlineDependencyInjection airlineObject = new AirlineDependencyInjection(new AirlineClass(buffer));
        private static TravelAgencyClass travelAgencyObject = new TravelAgencyClass(buffer);
        private static ConfirmationBufferClass confirmationBuffer = new ConfirmationBufferClass();

        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Monks Flight Booking System ");

            // creating 3 airline threads
            Thread[] airline = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                airline[i] = new Thread(new ThreadStart(airlineObject.runAirline));
                airline[i].Name = "Airline[" + (i + 1) + "]";
                airline[i].Start();
            }

            // travel agency's event handler subscribes to airline's price cut event
            AirlineClass.priceCutEvent += new priceCutDelegate(travelAgencyObject.priceCutEventHandler);

            // creating 5 travel agency threads
            Thread[] travelAgency = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                travelAgency[i] = new Thread(new ThreadStart(travelAgencyObject.runTravelAgency));
                travelAgency[i].Name = "Travel Agency[" + (i + 1) + "]";
                travelAgency[i].Start();
            }

            // confirmation buffer's event handler subscribes to order processing class's order confirm event
            OrderProcessingClass.orderConfirmationEvent += new orderConfirmationDelegate(confirmationBuffer.orderConfirmationEventHandler);
        }
    }
}
