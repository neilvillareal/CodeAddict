using System;
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
            int rotationCount = 0;

            if (n < 10)
            {
                return 0;
            }

            var digits = n.ToString().ToCharArray();

            double product = 1;

            for (int i = 0; i < digits.Length; i++)
            {
                product *= Char.GetNumericValue(digits[i]);
            }

            rotationCount++;

            if (product >= 10)
            {
                rotationCount += Persistence((long)product);
            }

            return rotationCount;
        }
    }
}
