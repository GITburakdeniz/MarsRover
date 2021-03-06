using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigationLibrary;
using Mission;
using System.Collections.Generic;
using System.IO;
using System;

namespace RoverTest
{
    /// <summary>
    /// Test cases of the Rover's Misson
    /// </summary>
    [TestClass]
    public class MissonTest
    {
        /// <summary>
        /// Tests PleatuBorder Function.
        /// </summary>
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

        /// <summary>
        /// Tests Create Rover Function.
        /// </summary>
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

        /// <summary>
        /// Tests Create Rover from Input.txt
        /// </summary>
        [TestMethod]
        public void TestCreateRoverFromInput()
        {
            DataHandling data = new DataHandling();
            Rover roverF = new Rover("1 2 N", "LMLMLMLMM");
            Rover roverY = new Rover("3 3 E", "MMRMMRMRRM");

            List<Rover> expectedRovers = new List<Rover>() { roverF, roverY };
            data.getMissionFromInputs();


            for (int i = 0; i < expectedRovers.Count; i++)
            {
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().XCordinate, expectedRovers[i].GetRoverPosition().XCordinate);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().YCordinate, expectedRovers[i].GetRoverPosition().YCordinate);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().Direction, expectedRovers[i].GetRoverPosition().Direction);
                Assert.AreEqual(data.MissionRovers[i].GetRoverPosition().IsStopped, expectedRovers[i].GetRoverPosition().IsStopped);
            }

        }

        /// <summary>
        /// Tests Rover's Mars Mission given Inputs.txt and compare Outputs.txt
        /// </summary>
        [TestMethod]
        public void TestMisson(){

            DataHandling missionData = new DataHandling();
            PositionHandling handleData = new PositionHandling();
            missionData.getMissionFromInputs();

            foreach (Rover rover in missionData.MissionRovers)
            {
                if (rover != null)
                {
                    rover.Explore();
                }
            }

            List<string> outputData = getOutputData();

            for (int i = 0; i < outputData.Count; i++)
            {
                string[] positionString = outputData[i].Split(" ");
                Position roverLastPosition = missionData.MissionRovers[i].GetRoverPosition();

                Assert.AreEqual(roverLastPosition.XCordinate, Convert.ToInt64(positionString[0]));
                Assert.AreEqual(roverLastPosition.YCordinate, Convert.ToInt64(positionString[1]));
                Assert.AreEqual(handleData.getCompassSymbolDirection(roverLastPosition.Direction),positionString[2]);
            }
        }

        /// <summary>
        /// Get mission output data from Outputs.txt 
        /// </summary>
        /// <returns> List of last position </returns>
        public List<string> getOutputData()
        {   
            List<string> outputData = new List<string>();
            string fileName = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Outputs.txt");
            StreamReader sr = File.OpenText(fileName);

            using (sr)
            {
                string line;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine() ?? "";
                    outputData.Add(line);

                }
            }
            return outputData;
        }

    }
}
