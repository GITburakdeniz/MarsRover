
using NavigationLibrary;

namespace Mission
{
    public class DataHandling
    {
        private readonly List<Rover> missionRovers;
        public DataHandling() { missionRovers = new List<Rover>(); }
        public List<Rover> MissionRovers { get { return missionRovers; } }
        public void AddRoverToMisson(Rover newRover) { missionRovers.Add(newRover); }
        public void getMissionFromInputs()
        {
            string fileName = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Inputs.txt");
            StreamReader sr = File.OpenText(fileName);

            using (sr)
            {
                Rover rover;
                string firstLine = sr.ReadLine() ?? "";
                string initialPosition, exploreRoute;

                if (firstLine != null)
                    setPlateauBorder(firstLine);

                while (!sr.EndOfStream)
                {
                    initialPosition = sr.ReadLine() ?? "";
                    exploreRoute = sr.ReadLine() ?? "";
                    AddRoverToMisson(createRover(initialPosition,exploreRoute));
                }
            }
        }

        public Rover createRover(string initialPosition, string exploreRoute)
        {
            return new Rover(initialPosition, exploreRoute);
        }

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
