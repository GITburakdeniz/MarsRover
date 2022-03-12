using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;
using System;

namespace RoverTest
{
    [TestClass]
    public class PositionTest
    {   
        PositionHandling checkPosition = new PositionHandling();

        [TestMethod]
        public void TestInvalidPositions()
        {
            string[] positions = { "-5 -5", "", "-1 0", ".", ";", "A B", "123aa aa54321", "123", "abc", "-1 8888 W", "A 1 W", "111tt 22 E" };
            foreach (var word in positions)
            {
                bool result = checkPosition.IsValidPosition(word);
                Assert.IsFalse(result,
                      string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestValidPositions()
        {
            string[] positions = { "5 5", "1 0", "0 0", "0 1", "999999 998899", "123 54321", "1 2 N", "3 2 N", "9 8 S","99999 998899 W" };
            foreach (var word in positions)
            {
                bool result = checkPosition.IsValidPosition(word);
                Assert.IsTrue(result,
                      string.Format("Expected for '{0}': true; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestValidDirection()
        {
            string[] positions = { "1 2 N", "3 2 W", "9 8 S", "99999 998899 W","0 0 E"};
            foreach (var word in positions)
            {
                bool result = checkPosition.IsValidDirection(word);
                Assert.IsTrue(result,
                      string.Format("Expected for '{0}': true; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestInValidDirection()
        {
            string[] positions = { "1 -2 N", "3 2 w", "9 8 SE", "99999 998899 Q", "0 -1 E", "0 E", "2 3","-1 0","11 22 R" };
            foreach (var word in positions)
            {
                bool result = checkPosition.IsValidDirection(word);
                Assert.IsFalse(result,
                      string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestValidIsInBorder()
        {
            string[] positions = { "0 0", "1 0", "3 1", "9999999 888888", "88888 88887" };

            Direction direction = Direction.West;
            Position position;

            Plateau.GetInstance().UpperXCordinate = Convert.ToInt64("9999999");
            Plateau.GetInstance().UpperYCordinate = Convert.ToInt64("888888");

            foreach (var word in positions)
            {
                string[] cor = word.Split(" ");
                position = new Position(Convert.ToInt64(cor[0]), Convert.ToInt64(cor[1]),direction);

                bool result = checkPosition.IsInBorder(position);    
                Assert.IsTrue(result,
                      string.Format("Expected for '{0}': true; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestInvalidIsInBorder()
        {
            string[] positions = { "0 -1", "-1 0", "-3 -1000", "9999999 888888", "1000 889" };

            Direction direction = Direction.West;
            Position position;

            Plateau.GetInstance().UpperXCordinate = Convert.ToInt64("999");
            Plateau.GetInstance().UpperYCordinate = Convert.ToInt64("888");

            foreach (var word in positions)
            {
                string[] cor = word.Split(" ");
                position = new Position(Convert.ToInt64(cor[0]), Convert.ToInt64(cor[1]), direction);

                bool result = checkPosition.IsInBorder(position);
                Assert.IsFalse(result,
                      string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
            }
        }
        [TestMethod]
        public void TestCompassDirection()
        {   
            Assert.AreEqual(Direction.North, checkPosition.getCompassDirection("N"));
            Assert.AreEqual(Direction.West, checkPosition.getCompassDirection("W"));
            Assert.AreEqual(Direction.East, checkPosition.getCompassDirection("E"));
            Assert.AreEqual(Direction.South, checkPosition.getCompassDirection("S"));

            Assert.AreEqual("N", checkPosition.getCompassSymbolDirection(Direction.North));
            Assert.AreEqual("W", checkPosition.getCompassSymbolDirection(Direction.West));
            Assert.AreEqual("E", checkPosition.getCompassSymbolDirection(Direction.East));
            Assert.AreEqual("S", checkPosition.getCompassSymbolDirection(Direction.South));
        }
    }
}