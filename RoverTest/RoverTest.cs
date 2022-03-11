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
            Rover roverF = new Rover("2 2 E", "MMLRMRL");

            Assert.IsNotNull(roverF);
            CollectionAssert.AreEqual(expectedTurns, roverF.GetRoverRoute());
        }

        [TestMethod]
        public void testCreatePosition()
        {
            Rover roverF = new Rover("2 4 E", "MMLRMRL");
            Assert.IsNotNull(roverF);
            Assert.AreEqual(Direction.East,roverF.GetRoverPosition().Direction);
            Assert.AreEqual(2, roverF.GetRoverPosition().XCordinate);
            Assert.AreEqual(4, roverF.GetRoverPosition().YCordinate);

            Rover roverS = new Rover("6 5 W", "MMLRMRL");
            Assert.IsNotNull(roverS);
            Assert.AreEqual(Direction.West, roverS.GetRoverPosition().Direction);
            Assert.AreEqual(6, roverS.GetRoverPosition().XCordinate);
            Assert.AreEqual(5, roverS.GetRoverPosition().YCordinate);

        }

    }
}
