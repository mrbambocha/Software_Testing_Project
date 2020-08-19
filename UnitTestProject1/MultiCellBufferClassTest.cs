using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Monks_Flight_Booking_System.Utility;

namespace UnitTestProject1
{
    [TestClass]
    public class MultiCellBufferClassTest
    {
        [TestMethod]
        public void IsAddedToBufferTest()
        {
            MultiCellBufferClass multiCell = new MultiCellBufferClass();
            var result = multiCell.addToBuffer("1,2,3,10.0");
            Assert.IsTrue(result);
            Assert.IsTrue(multiCell.addToBuffer("1,4,5,6"));
            Assert.IsTrue(multiCell.addToBuffer("8755"));
        }

        [TestMethod]
        public void AddedToBufferFailTest()
        {
            MultiCellBufferClass multiCell = new MultiCellBufferClass();
            multiCell.addToBuffer("1,2,3,10.0");
            multiCell.addToBuffer("1,4,5,6");
            multiCell.addToBuffer("8755");
            var result = multiCell.addToBuffer("12315234");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveFromTestBufferSuccessTest()
        {
            MultiCellBufferClass multiCell = new MultiCellBufferClass();
            multiCell.addToBuffer("1,2,3,10.0,8");
            multiCell.addToBuffer("1,4,5,6,9");
            multiCell.addToBuffer("8,7,5,5,5");

            //Removing from the buffer
            var removedString = multiCell.removeFromBuffer("3");
            Assert.AreEqual(removedString, "1,2,3,10.0,8");
        }

        [TestMethod]
        public void BufferCountTest()
        {
            MultiCellBufferClass multiCell = new MultiCellBufferClass();
            multiCell.addToBuffer("1,2,3,10.0,8");
            multiCell.addToBuffer("1,4,5,6,9");
            multiCell.addToBuffer("8,7,5,5,5");

            //Checking the number of count
            Assert.AreEqual(3, multiCell.orderStringBuffer.Count);
        }

    }
}
