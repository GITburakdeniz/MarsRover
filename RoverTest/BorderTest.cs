using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;

namespace RoverTest
{
    [TestClass]
    public class BorderTest
    {
        [TestMethod]
        public void TestBorders()
        {
            string[] borders = { "-5 -5", "", "-1 0", ".", ";", "A B", "123aa aa54321", "123", "abc" };
            foreach (var word in borders)
            {
                bool result = word.IsValidBorder();
                Assert.IsFalse(result,
                      string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
            }
        }
    }
}