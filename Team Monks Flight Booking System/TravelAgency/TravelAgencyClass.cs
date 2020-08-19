using System;
using System.Collections.Generic;
using System.Threading;
using Team_Monks_Flight_Booking_System.Utility;

namespace Team_Monks_Flight_Booking_System.TravelAgency
{
    public class TravelAgencyClass
    {
        // keeps a mapping of price difference range against the number of tickets to order
        private Dictionary<string, int> priceTicketMap = new Dictionary<string, int>()
        {
            {"Default", 5},
            {"100-200", 10},
            {"200-300", 12},
            {"300-400", 15},
            {"400-500", 18},
            {"500-600",20},
            {"600-700",22},
            {"700-800",25}
        };

        private static MultiCellBufferClass buffer;
        private object lockPriceCutEventHandler = new object();

        private static string receiverId;
        private static int numOfTickets;
        private static double ticketUnitPrice;
        private static int cardNo;

        private bool hasPriceCutEventHappened = false;

        public TravelAgencyClass(MultiCellBufferClass OrderBuffer)
        {
            buffer = OrderBuffer;
        }

        // Travel agency's thread method
        public void runTravelAgency()
        {
            Console.Write("\n {0} is inside runTravelAgency() ", Thread.CurrentThread.Name);

            // declaring some variables that would be local to each thread 
            DateTime orderTimeStamp;

            for (int i = 0; i < 70; i++)
            {
                Thread.Sleep(800);

                // travel agency is event driven, hence checking if an event occurred only then proceeding with creating order 
                if (hasPriceCutEventHappened)
                {
                    OrderClass orderObject = new OrderClass();
                    orderObject.SenderId = Thread.CurrentThread.Name;
                    orderObject.CardNo = cardNo;
                    orderObject.ReceiverID = receiverId;
                    orderObject.NumTickets = numOfTickets;
                    orderObject.UnitPrice = ticketUnitPrice;

                    string orderString = EncoderDecoderClass.encodeOrderObject(orderObject);
                    Console.WriteLine(" {0} built order: {1}", Thread.CurrentThread.Name, orderString);

                    // saving timestamp of the order before sending it to buffer
                    orderTimeStamp = DateTime.Now;

                    // travel agency sends the encoded string to one of the free cells in buffer
                    buffer.addToBuffer(orderString);

                    // setting the flag as false as the order for this event has been added to buffer
                    hasPriceCutEventHappened = false;
                }
            }
        }

        // Event handler for price cut event
        public void priceCutEventHandler(double previousPrice, double newPrice, string airlineThreadName)
        {
            Random rnd = new Random();
            lock (lockPriceCutEventHandler)
            {
                hasPriceCutEventHappened = true;
                numOfTickets = calculateNumberOfTickets(previousPrice, newPrice);
                receiverId = airlineThreadName;
                ticketUnitPrice = newPrice;
                cardNo = rnd.Next(5000, 7000);
            }
        }

        // calculate number of tickets based on the previous price and current price
        public int calculateNumberOfTickets(double previousPrice, double newPrice)
        {
            int noOfTickets = 0;
            int priceDifference = (int)(previousPrice - newPrice);

            if (priceDifference > 100 & priceDifference <= 200)
                noOfTickets = priceTicketMap["100-200"];
            else if (priceDifference > 200 & priceDifference <= 300)
                noOfTickets = priceTicketMap["200-300"];
            else if (priceDifference > 300 & priceDifference <= 400)
                noOfTickets = priceTicketMap["300-400"];
            else if (priceDifference > 400 & priceDifference <= 500)
                noOfTickets = priceTicketMap["400-500"];
            else if (priceDifference > 500 & priceDifference <= 600)
                noOfTickets = priceTicketMap["500-600"];
            else if (priceDifference > 600 & priceDifference <= 700)
                noOfTickets = priceTicketMap["600-700"];
            else if (priceDifference > 700 & priceDifference <= 800)
                noOfTickets = priceTicketMap["700-800"];
            else
                noOfTickets = priceTicketMap["Default"];

            return noOfTickets;
        }
    }
}
