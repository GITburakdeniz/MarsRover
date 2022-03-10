using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;
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
    }
}
