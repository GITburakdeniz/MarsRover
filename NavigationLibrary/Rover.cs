
namespace NavigationLibrary
{
    public class Rover
    {
        private Position position;
        private NavigationHandling navigation;
        private PositionHandling checkPosition;

        public Rover(string initialPosition, string exploreRoute) 
        {
            checkPosition = new PositionHandling();
            navigation = new NavigationHandling();
            position = createPosition(initialPosition);
            CreateRoute(exploreRoute);
        }
        public Position createPosition(string initialPosition)
        {
                if (checkPosition.IsValidDirection(initialPosition))
                {
                    string[] positions = initialPosition.Split(" ");
                    
                    return new Position(Convert.ToInt64(positions[0]), Convert.ToInt64(positions[1]),checkPosition.getCompassDirection(positions[2]));
                }
            return null;
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

        public Position GetRoverPosition()
        {
            return position;
        }
    }
}
