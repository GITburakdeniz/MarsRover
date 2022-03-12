using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;
using Mission;
using System.Collections.Generic;

namespace RoverTest
{
    [TestClass]
    public class MissonTest
    {
        [TestMethod]
        public void TestValidPleatuBordersInput()
        {
            DataHandling missonData = new DataHandling();
            missonData.setPlateauBorder("5 5");

            Assert.AreEqual(5, Plateau.GetInstance().UpperXCordinate);
            Assert.AreEqual(5, Plateau.GetInstance().UpperYCordinate);
            Assert.AreEqual(0, Plateau.GetInstance().LowerXCordinate);
            Assert.AreEqual(0, Plateau.GetInstance().LowerYCordinate);

            missonData.setPlateauBorder("9998887775555 4444333322226666");

            Assert.AreEqual(9998887775555, Plateau.GetInstance().UpperXCordinate);
            Assert.AreEqual(4444333322226666, Plateau.GetInstance().UpperYCordinate);
            Assert.AreEqual(0, Plateau.GetInstance().LowerXCordinate);
            Assert.AreEqual(0, Plateau.GetInstance().LowerYCordinate);
        }

        [TestMethod]
        public void TestCreateRover()
        {
            DataHandling data = new DataHandling();
            Rover roverF = new Rover("2 4 E", "MMLRMRL");
            Rover roverY = new Rover("0 0 S", "MLM");
            Rover roverZ = new Rover("0 0 N", "MMLMMRRMLMLLMMLMMMML");
            Rover roverT = new Rover("50 60 W", "MMLMMRRMLRRMLMRRMLRRMM");

            List<Rover> expectedRovers = new List<Rover>() { roverF, roverY, roverZ, roverT };
            data.AddRoverToMisson(data.createRover("2 4 E", "MMLRMRL"));
            data.AddRoverToMisson(data.createRover("0 0 S", "MLM"));
            data.AddRoverToMisson(data.createRover("0 0 N", "MMLMMRRMLMLLMMLMMMML"));
            data.AddRoverToMisson(data.createRover("50 60 W", "MMLMMRRMLRRMLMRRMLRRMM"));
            
            for (int i = 0; i < expectedRovers.Count; i++)
            {
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().XCordinate, expectedRovers[i].GetRoverPosition().XCordinate);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().YCordinate, expectedRovers[i].GetRoverPosition().YCordinate);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().Direction, expectedRovers[i].GetRoverPosition().Direction);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().IsStopped, expectedRovers[i].GetRoverPosition().IsStopped);
            }

        }

        [TestMethod]
        public void TestCreateRoverFromInput()
        {
            DataHandling data = new DataHandling();
            Rover roverF = new Rover("1 2 N", "LMLMLMLMM");
            Rover roverY = new Rover("3 3 E", "MMRMMRMRRM");

            List<Rover> expectedRovers = new List<Rover>() { roverF, roverY};
            data.getMissionFromInputs();

            
            for (int i = 0; i < expectedRovers.Count; i++)
            {
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().XCordinate, expectedRovers[i].GetRoverPosition().XCordinate);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().YCordinate, expectedRovers[i].GetRoverPosition().YCordinate);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().Direction, expectedRovers[i].GetRoverPosition().Direction);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().IsStopped, expectedRovers[i].GetRoverPosition().IsStopped);
            }

        }
    }
}
