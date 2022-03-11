
namespace NavigationLibrary
{
    public class Rover
    {
        private Position position;
        private NavigationHandling navigation;
        private string exploreRoute;

        public Rover(long initialXCor, long initialYCor, Direction initialDirection, string route) 
        {
            position = new Position(initialXCor,initialYCor,initialDirection);
            navigation = new NavigationHandling();
            exploreRoute = route;
        }

        public void CreateRoute() 
        {
             if (navigation != null && position != null)
            {
                if (navigation.IsValidRoute(exploreRoute))
                {
                    
                }
            }
        }

        public void Explore()
        {

        }
    }
}
