using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;
using System.Collections.Generic;

namespace RoverTest
{
    /// <summary>
    /// Test cases of the Rover's abilities
    /// </summary>
    [TestClass]
    public class RoverTest
    {
        /// <summary>
        /// Tests Create exploration route Function.
        /// </summary>
        [TestMethod]
        public void testCreateRoute()
        {
            List<Turn> expectedTurns = new List<Turn>() { Turn.Foward, Turn.Foward, Turn.Left, Turn.Right, Turn.Foward, Turn.Right, Turn.Left };
            Rover roverF = new Rover("2 2 E", "MMLRMRL");

            Assert.IsNotNull(roverF);
            CollectionAssert.AreEqual(expectedTurns, roverF.GetRoverRoute());
        }

        /// <summary>
        /// Tests Create initial position of the rover.
        /// </summary>
        [TestMethod]
        public void TestCreatePosition()
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

        /// <summary>
        /// Tests Rover's exploration result
        /// </summary>
        [TestMethod]
        public void TestExplorer()
        {
            Plateau.GetInstance().UpperXCordinate = 5;
            Plateau.GetInstance().UpperYCordinate = 5;

            Rover roverF = new Rover("2 4 E", "MMLRMRL");
            roverF.Explore();
            Assert.AreEqual(5,roverF.GetRoverPosition().XCordinate);
            Assert.AreEqual(4, roverF.GetRoverPosition().YCordinate);
            Assert.AreEqual(Direction.East, roverF.GetRoverPosition().Direction);
            Assert.IsFalse(roverF.GetRoverPosition().IsStopped);
      
            Plateau.GetInstance().UpperXCordinate = 0;
            Plateau.GetInstance().UpperYCordinate = 0;

            Rover roverY = new Rover("0 0 S", "MLM");
            roverY.Explore();
            Assert.AreEqual(0, roverY.GetRoverPosition().XCordinate);
            Assert.AreEqual(0, roverY.GetRoverPosition().YCordinate);
            Assert.AreEqual(Direction.East, roverY.GetRoverPosition().Direction);
            Assert.IsTrue(roverY.GetRoverPosition().IsStopped);

            Plateau.GetInstance().UpperXCordinate = 2;
            Plateau.GetInstance().UpperYCordinate = 1;

            Rover roverZ = new Rover("0 0 N", "MMLMMRRMLMLLMMLMMMML");
            roverZ.Explore();
            Assert.AreEqual(2, roverZ.GetRoverPosition().XCordinate);
            Assert.AreEqual(0, roverZ.GetRoverPosition().YCordinate);
            Assert.AreEqual(Direction.North, roverZ.GetRoverPosition().Direction);
            Assert.IsFalse(roverZ.GetRoverPosition().IsStopped);

            Plateau.GetInstance().UpperXCordinate = 70;
            Plateau.GetInstance().UpperYCordinate = 90;

            Rover roverT = new Rover("50 60 W", "MMLMMRRMLRRMLMRRMLRRMM");
            roverT.Explore();
            Assert.AreEqual(47, roverT.GetRoverPosition().XCordinate);
            Assert.AreEqual(59, roverT.GetRoverPosition().YCordinate);
            Assert.AreEqual(Direction.West, roverT.GetRoverPosition().Direction);
            Assert.IsFalse(roverT.GetRoverPosition().IsStopped);

        }

    }
}
