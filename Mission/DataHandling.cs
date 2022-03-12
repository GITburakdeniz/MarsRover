
using NavigationLibrary;

namespace Mission
{
    /// <summary>
    /// Handling Rovers and Plateau data from Inputs.txt
    /// </summary>
    public class DataHandling
    {
        private readonly List<Rover> missionRovers;
        public DataHandling() { missionRovers = new List<Rover>(); }
        public List<Rover> MissionRovers { get { return missionRovers; } }
        public void AddRoverToMisson(Rover newRover) { missionRovers.Add(newRover); }


        /// <summary>
        /// Reads mission Input data, then sets plateau border and creates rovers of the mission.
        /// </summary>
        /// <returns> No return </returns>
        public void getMissionFromInputs()
        {
            string fileName = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Inputs.txt");
            StreamReader sr = File.OpenText(fileName);

            using (sr)
            {
                string firstLine = sr.ReadLine() ?? "";
                string initialPosition, exploreRoute;

                if (firstLine != null)
                    setPlateauBorder(firstLine);  // setPlateau Border from first line of input file.

                while (!sr.EndOfStream)
                {
                    initialPosition = sr.ReadLine() ?? "";
                    exploreRoute = sr.ReadLine() ?? "";
                    AddRoverToMisson(createRover(initialPosition,exploreRoute)); // created rover with initial values and add to the misson.
                }
            }
        }

        /// <summary>
        /// Gets initial position and exploration route, then creates and returns Rover object.
        /// </summary>
        /// <param name="initialPosition">initial poisiton of the Rover</param>
        /// <param name="exploreRoute">exploration route of the Rover</param>
        /// <returns> Rover type Object. </returns>
        public Rover createRover(string initialPosition, string exploreRoute)
        {
            return new Rover(initialPosition, exploreRoute);
        }

        /// <summary>
        /// Gets plateau upper border position coordinates,then sets plateau border.
        /// </summary>
        /// <param name="borders">initial poisiton of the Rover</param>
        /// <returns> No returns </returns>
        public void setPlateauBorder(string borders)
        {   
            PositionHandling checkBorder  = new PositionHandling();

            if (checkBorder.IsValidPosition(borders))
            {
                string[] values = borders.Split(' ');

                Plateau.GetInstance().UpperXCordinate = Convert.ToInt64(values[0]);
                Plateau.GetInstance().UpperYCordinate = Convert.ToInt64(values[1]);
            }

        }
    }
}
