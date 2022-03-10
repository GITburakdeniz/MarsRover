using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;

namespace RoverTest
{
    [TestClass]
    public class BorderTest
    {
        [TestMethod]
        public void TestInvalidBorders()
        {
            string[] borders = { "-5 -5", "", "-1 0", ".", ";", "A B", "123aa aa54321", "123", "abc", "-1 8888 W", "A 1 W", "111tt 22 E" };
            foreach (var word in borders)
            {
                bool result = word.IsValidBorder();
                Assert.IsFalse(result,
                      string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestValidBorders()
        {
            string[] borders = { "5 5", "1 0", "0 0", "0 1", "999999 998899", "123 54321", "1 2 N", "3 2 N", "9 8 S","99999 998899 W" };
            foreach (var word in borders)
            {
                bool result = word.IsValidBorder();
                Assert.IsTrue(result,
                      string.Format("Expected for '{0}': true; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestValidDirection()
        {
            string[] borders = { "1 2 N", "3 2 W", "9 8 S", "99999 998899 W","0 0 E"};
            foreach (var word in borders)
            {
                bool result = word.IsValidDirection();
                Assert.IsTrue(result,
                      string.Format("Expected for '{0}': true; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestInValidDirection()
        {
            string[] borders = { "1 -2 N", "3 2 w", "9 8 SE", "99999 998899 Q", "0 -1 E", "0 E", "2 3","-1 0","11 22 R" };
            foreach (var word in borders)
            {
                bool result = word.IsValidDirection();
                Assert.IsFalse(result,
                      string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
            }
        }
    }
}