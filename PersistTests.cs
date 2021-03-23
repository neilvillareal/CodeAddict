using NUnit.Framework;

namespace CodeAddict
{
    [TestFixture]
    public class PersistTests
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(3, Persist.Persistence(39));
            Assert.AreEqual(0, Persist.Persistence(4));
            Assert.AreEqual(2, Persist.Persistence(25));
            Assert.AreEqual(4, Persist.Persistence(999));
        }
    }


    public class Persist
    {
        public static int Persistence(long n)
        {
            // add your magical code here.
            return 0;
        }
    }
}
