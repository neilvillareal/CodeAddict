using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAddict
{
    [TestFixture]
    public class TenPinBowlingTests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(20, TenPinBowling.BowlingScore("11 11 11 11 11 11 11 11 11 11"));
            Assert.AreEqual(300, TenPinBowling.BowlingScore("X X X X X X X X X XXX"));
            Assert.AreEqual(115, TenPinBowling.BowlingScore("00 5/ 4/ 53 33 22 4/ 5/ 45 XXX"));
            Assert.AreEqual(117, TenPinBowling.BowlingScore("00 70 3/ 7/ 5/ 09 16 7/ 36 XXX"));
        }
    }

    public static class TenPinBowling
    {
        public static int BowlingScore(string frames)
        {
            //add your magical code here.
            return 0;
        }
    }
}
