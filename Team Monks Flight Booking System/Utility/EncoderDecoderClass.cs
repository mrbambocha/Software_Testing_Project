using System;
using Team_Monks_Flight_Booking_System.TravelAgency;

namespace Team_Monks_Flight_Booking_System.Utility
{
    public class EncoderDecoderClass
    {
        // The Encoder will convert an OrderObject into a string
        public static string encodeOrderObject(OrderClass orderObject)
        {
            string delimit = ",";
            string outputOrderString = orderObject.SenderId + delimit + orderObject.CardNo + delimit +
                orderObject.ReceiverID + delimit + orderObject.NumTickets + delimit + orderObject.UnitPrice;

            return outputOrderString;
        }

        // The Decoder will convert the encoded string back into the OrderObject
        public static OrderClass decodeOrderObject(string orderString)
        {
            char[] delimiters = new char[] { ',' };
            string[] values = orderString.Split(delimiters);

            OrderClass outputOrderObject = new OrderClass();
            outputOrderObject.SenderId = values[0];
            outputOrderObject.CardNo = Convert.ToInt32(values[1]);
            outputOrderObject.ReceiverID = values[2];
            outputOrderObject.NumTickets = Convert.ToInt32(values[3]);
            outputOrderObject.UnitPrice = Convert.ToDouble(values[4]);

            return outputOrderObject;
        }
    }
}
