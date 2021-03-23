using NUnit.Framework;

namespace CodeAddict
{
    [TestFixture]
    public class ArrayDiffTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new int[] { 2 }, ArrayDiff.ArrayDiffFunc(new int[] { 1, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 2, 2 }, ArrayDiff.ArrayDiffFunc(new int[] { 1, 2, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 1 }, ArrayDiff.ArrayDiffFunc(new int[] { 1, 2, 2 }, new int[] { 2 }));
            Assert.AreEqual(new int[] { 1, 2, 2 }, ArrayDiff.ArrayDiffFunc(new int[] { 1, 2, 2 }, new int[] { }));
            Assert.AreEqual(new int[] { }, ArrayDiff.ArrayDiffFunc(new int[] { }, new int[] { 1, 2 }));
        }
    }

    public class ArrayDiff
    {
        public static int[] ArrayDiffFunc(int[] a, int[] b)
        {
            // add your magical code here.
            return new int[0];
        }
    }
}
