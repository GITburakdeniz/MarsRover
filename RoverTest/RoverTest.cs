using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;
using System.Collections.Generic;

namespace RoverTest
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void testCreateRoute()
        {
            List<Turn> expectedTurns = new List<Turn>() { Turn.Foward, Turn.Foward, Turn.Left, Turn.Right, Turn.Foward, Turn.Right, Turn.Left };
            Rover roverF = new Rover(2, 2, Direction.South, "MMLRMRL");

            Assert.IsNotNull(roverF);
            CollectionAssert.AreEqual(expectedTurns, roverF.GetRoverRoute());
        }

    }
}
