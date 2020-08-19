using System;
using System.Collections.Generic;
using System.Threading;

namespace Team_Monks_Flight_Booking_System.Utility
{
    //MultiCellBuffer class is used for the communication between 
    //the travel agencies (clients) and the airlines (servers) 
    public class MultiCellBufferClass
    {
        // The number of cells available 
        private const int CELL_SIZE = 3;

        // manage the availability of the cells
        private static Semaphore semaphore = new Semaphore(CELL_SIZE, CELL_SIZE);

        // this is the buffer object used for writing and reading data
        public List<string> orderStringBuffer = new List<string>();

        // adding order string received from travel agencies to buffer object
        public bool addToBuffer(string orderString)
        {
            bool successs = false;

            // placing a monitor on buffer object as it will be accessed by multiple threads at same time
            Monitor.Enter(orderStringBuffer);
            try
            {
                // notify other threads if buffer already full
                if (orderStringBuffer.Count > (CELL_SIZE - 1))
                {
                    Monitor.PulseAll(orderStringBuffer);
                }
                else
                {
                    try
                    {
                        semaphore.WaitOne();
                        orderStringBuffer.Add(orderString);
                        Console.WriteLine(" {0} added order data to cell buffer", Thread.CurrentThread.Name);
                        successs = true;
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
            }
            finally
            {
                Monitor.Exit(orderStringBuffer);
            }
            return successs;
        }

        // removing an order string from orderStringBuffer on the basis of receiverId
        public string removeFromBuffer(string receiverId)
        {
            string removedOrderString = null;

            // placing a monitor on orderStringBuffer as this object will be accessed by multiple threads at same time
            Monitor.Enter(orderStringBuffer);
            try
            {
                // notify other threads if buffer is empty
                if (orderStringBuffer.Count < 1)
                {
                    Monitor.PulseAll(orderStringBuffer);
                }
                else
                {
                    try
                    {
                        semaphore.WaitOne();
                        foreach (string str in orderStringBuffer)
                        {
                            if (str.Contains(receiverId))
                            {
                                removedOrderString = str;
                                orderStringBuffer.Remove(str);
                                Console.WriteLine(" {0} removed order data from cell buffer", Thread.CurrentThread.Name);
                                break;
                            }
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
            }
            finally
            {
                Monitor.Exit(orderStringBuffer);
            }
            return removedOrderString;
        }
    }
}
