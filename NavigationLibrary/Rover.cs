
namespace NavigationLibrary
{
    public class Rover
    {
        private Position position;
        private NavigationHandling navigation;

        public Rover(long initialXCor, long initialYCor, Direction initialDirection, string exploreRoute) 
        {
            position = new Position(initialXCor,initialYCor,initialDirection);
            navigation = new NavigationHandling();
            CreateRoute(exploreRoute);
        }

        public void CreateRoute(string exploreRoute) 
        {
             if (navigation != null && position != null)
            {
                if (navigation.IsValidRoute(exploreRoute))
                {
                    foreach (char turnCh in exploreRoute)
                    {
                        if (turnCh == 'L')
                            navigation.AddNewRoute(Turn.Left);
                        if (turnCh == 'R')
                            navigation.AddNewRoute(Turn.Right);
                        if (turnCh == 'M')
                            navigation.AddNewRoute(Turn.Foward);
                    }
                }
            }
        }

        public void Explore()
        {

        }

        public List<Turn> GetRoverRoute()
        {
            return navigation.NavigationRoute;
        }
    }
}
