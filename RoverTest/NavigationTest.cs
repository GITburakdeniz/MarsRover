using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;
using System;
using System.Collections.Generic;

namespace RoverTest
{
    [TestClass] 
    public class NavigationTest
    {
        [TestMethod]
        public void TestInvalidTurns()
        {
            string[] turns = { "LLTLL", "MMRU", "1 0", ".", ";", "rml", "RMLI","L MM", "MMRMM RMRRM" };
            foreach (var word in turns)
            {
                bool result = word.IsValidTurn();
                Assert.IsFalse(result,
                      string.Format("Expected for '{0}': false; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestValidTurns()
        {
            string[] turns = { "LLLL", "MM", "LMLMLMLMM", "MMRMMRMRRM", "MMRMMRMRRLML" };
            foreach (var word in turns)
            {
                bool result = word.IsValidTurn();
                Assert.IsTrue(result,
                      string.Format("Expected for '{0}': true; Actual: {1}",
                                    word, result));
            }
        }

        [TestMethod]
        public void TestValidLeftDirection()
        {   
            List<Direction> currentDirections = new(){ Direction.North, Direction.South, Direction.East, Direction.West };
            List<Direction> expectedDirections = new() { Direction.West, Direction.East, Direction.North, Direction.South };
            List<Direction> nextDirections = new();

            foreach (var direction in currentDirections)
            {   
                nextDirections.Add(direction.GetLeftDirection());
            }
            
            CollectionAssert.AreEqual(nextDirections, expectedDirections);
        }

        [TestMethod]
        public void TestValidRightDirection()
        {
            List<Direction> currentDirections = new() { Direction.North, Direction.South, Direction.East, Direction.West };
            List<Direction> expectedDirections = new() { Direction.East, Direction.West, Direction.South, Direction.North };
            List<Direction> nextDirections = new();

            foreach (var direction in currentDirections)
            {
                nextDirections.Add(direction.GetRightDirection());
            }

            CollectionAssert.AreEqual(nextDirections, expectedDirections);
        }

        [TestMethod]
        public void TestValidMoveFoward()
        {
            Plateau.GetInstance().UpperXCordinate = 5;
            Plateau.GetInstance().UpperYCordinate = 5;

            Direction direction = Direction.North;
            Position position = new Position(3, 4, direction);

            position.MoveFoward();
            Assert.AreEqual(3, position.XCordinate);
            Assert.AreEqual(5, position.YCordinate);

            position.MoveFoward();
            Assert.IsTrue(position.IsStopped);
            position.IsStopped = false;

            direction = Direction.South;
            position = new Position(4, 5, direction);

            position.MoveFoward();
            Assert.AreEqual(4, position.XCordinate);
            Assert.AreEqual(4, position.YCordinate);

            direction = Direction.West;
            position = new Position(4, 5, direction);

            position.MoveFoward();
            Assert.AreEqual(3, position.XCordinate);
            Assert.AreEqual(5, position.YCordinate);

            position.MoveFoward();
            Assert.AreEqual(2, position.XCordinate);
            Assert.AreEqual(5, position.YCordinate);
            Assert.IsFalse(position.IsStopped);

            direction = Direction.East;
            position = new Position(0, 0, direction);

            position.MoveFoward();
            Assert.AreEqual(1, position.XCordinate);
            Assert.AreEqual(0, position.YCordinate);

            position.MoveFoward();
            position.MoveFoward();
            position.MoveFoward();
            position.MoveFoward();
            position.MoveFoward();
            position.MoveFoward();

            Assert.IsTrue(position.IsStopped);

        }
    }
}
