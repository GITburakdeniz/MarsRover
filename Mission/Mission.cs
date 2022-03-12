using NavigationLibrary;

namespace Mission
{
    class Mission
    {   
        static void Main()
        {
            DataHandling missionData = new DataHandling();
            missionData.getMissionFromInputs();
            
            foreach(Rover rover in missionData.MissionRovers)
            {
                if (rover != null)
                {
                    rover.Explore();
                    Console.WriteLine(rover.GetRoverPosition().XCordinate +" "+ rover.GetRoverPosition().YCordinate +" "+ rover.GetRoverPosition().CompassDirectionSymbol);
                }
            }
        }
    }
}
