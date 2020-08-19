using System;
using System.Threading;
using Team_Monks_Flight_Booking_System.Utility;
using Team_Monks_Flight_Booking_System.TravelAgency;

namespace Team_Monks_Flight_Booking_System.Airline
{
    // price cut event delegate declaration
    public delegate void priceCutDelegate(double previousPrice, double newPrice, string threadName);

    public class AirlineClass
    {
        // price cut event declaration
        public static event priceCutDelegate priceCutEvent;
        private static MultiCellBufferClass buffer;

        private object lockChangePriceMethod = new object();
        private object lockPricingModel = new object();

        private double Airline_1_Price = 500;
        private double Airline_2_Price = 600;
        private double Airline_3_Price = 700;

        [ThreadStatic]
        public static int availableTickets = 10;

        public AirlineClass(MultiCellBufferClass buffer)
        {
            AirlineClass.buffer = buffer;
        }

        // thread method of airline class
        public void runAirline()
        {
            Console.Write(" {0} is inside runAirline() \n", Thread.CurrentThread.Name);

            // declaring price cut counter for each airline thread
            int priceCutCounter = 0;
            double baseTicketUnitPrice = 0;

            for (int i = 0; i < 70; i++)
            {
                Thread.Sleep(300);

                // setting ticket price for all airline threads
                if (Thread.CurrentThread.Name.Equals("Airline[1]"))
                {
                    baseTicketUnitPrice = Airline_1_Price;
                }
                if (Thread.CurrentThread.Name.Equals("Airline[2]"))
                {
                    baseTicketUnitPrice = Airline_2_Price;
                }
                if (Thread.CurrentThread.Name.Equals("Airline[3]"))
                {
                    baseTicketUnitPrice = Airline_3_Price;
                }

                // fetching new price from pricing model for each airline thread
                double newPrice = getPriceFromPricingModel();

                Console.WriteLine(" {0} offered New Price is {1} ", Thread.CurrentThread.Name, newPrice);

                // calling change price method that will change the ticket price and emit price cut event in case of price drop
                priceCutCounter = changePrice(baseTicketUnitPrice, newPrice, Thread.CurrentThread.Name, priceCutCounter);

                // after 20 price cuts an airline thread will terminate
                if (priceCutCounter < 20)
                {
                    OrderClass orderObject = null;

                    // removing a order cell from buffer by sending the current thread's name
                    string orderString = buffer.removeFromBuffer(Thread.CurrentThread.Name);

                    // checking if the orderString received from buffer is not null and then proceeding with order processing
                    if (orderString != null)
                    {
                        Console.WriteLine(" {0} has removed order: {1}", Thread.CurrentThread.Name, orderString);

                        orderObject = EncoderDecoderClass.decodeOrderObject(orderString);

                        // sending the order object for order processing
                        OrderProcessingClass orderProc = new OrderProcessingClass(orderObject);
                        Thread orderProcessThread = new Thread(new ThreadStart(orderProc.runOrderProcessing));
                        orderProcessThread.Start();
                    }
                }
                else
                {
                    Console.WriteLine(" Stopping {0} because it's price counter reached {1}", Thread.CurrentThread.Name, priceCutCounter);
                    break; //  the airline thread exits when it completes 20 price cuts
                }
            }
        }

        // pricing model that generates random prices using random function
        public double getPriceFromPricingModel()
        {
            lock (lockPricingModel)
            {
                Random rand = new Random();
                double price = rand.Next(100, 900); // Generate a random price
                return price;
            }
        }

        // change price method that will change the ticket price and emit price cut event in case of price drop
        public int changePrice(double previousPrice, double newPrice, string threadName, int priceCutCounter)
        {
            lock (lockChangePriceMethod)
            {
                // Checking if there is a price cut
                if (newPrice < previousPrice)
                {
                    // to check if there is at least one subscriber
                    if (priceCutEvent != null)
                    {
                        // emit event to subscribers
                        priceCutEvent(previousPrice, newPrice, threadName);
                        priceCutCounter++;
                        Console.WriteLine(" {0} emits price cut event with price cut counter:{1}", threadName, priceCutCounter);
                    }
                }
                if (threadName.Equals("Airline[1]"))
                {
                    Airline_1_Price = newPrice;
                }
                if (threadName.Equals("Airline[2]"))
                {
                    Airline_2_Price = newPrice;
                }
                if (threadName.Equals("Airline[3]"))
                {
                    Airline_3_Price = newPrice;
                }
            }

            return priceCutCounter;
        }
    }
}
