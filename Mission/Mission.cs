using NavigationLibrary;

namespace Mission
{
    class Mission
    {   
        static void Main(string[] args)
        {
            DataHandling missionData = new DataHandling();
            missionData.getMissionFromInputs();
        }
    }
}
