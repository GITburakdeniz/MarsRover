
namespace NavigationLibrary
{
    /// <summary>
    /// The class that contains the rover data and capabilities.
    /// </summary>
    public class Rover
    {
        private Position position;
        private NavigationHandling navigation;
        private PositionHandling checkPosition;

        /// <summary>
        /// Creates its current position and exploration route.
        /// </summary>
        public Rover(string initialPosition, string exploreRoute) 
        {
            checkPosition = new PositionHandling();
            navigation = new NavigationHandling();
            position = createPosition(initialPosition);
            CreateRoute(exploreRoute);
        }

        /// <summary>
        /// Creates  current position of the Rover.
        /// </summary>
        /// <param name="initialPosition"> initial Position of the Rover</param>
        /// <returns> Position object </returns>
        public Position createPosition(string initialPosition)
        {
                if (checkPosition.IsValidDirection(initialPosition))
                {
                    string[] positions = initialPosition.Split(" ");
                    
                    return new Position(Convert.ToInt64(positions[0]), Convert.ToInt64(positions[1]),checkPosition.getCompassDirection(positions[2]));
                }
            return null;
        }

        /// <summary>
        /// Creates exploration route of the Rover.
        /// </summary>
        /// <param name="exploreRoute"> explore Route of the Rover</param>
        /// <returns> Position object </returns>
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

        /// <summary>
        /// Starts rover exploration.
        /// </summary>
        /// <returns> No returns </returns>
        public void Explore()
        {
            foreach(Turn nextRoute in GetRoverRoute())
            {
                    if (nextRoute == Turn.Foward && !position.IsStopped)
                        navigation.MoveFoward(position);
                    if (nextRoute == Turn.Left)
                        navigation.TurnLeft(position);
                    if (nextRoute == Turn.Right)
                        navigation.TurnRight(position);
            }
        }

        /// <summary>
        /// Get rover's route.
        /// </summary>
        /// <returns> List of Turns numeration which contains route directions </returns>
        public List<Turn> GetRoverRoute()
        {
            return navigation.NavigationRoute;
        }

        /// <summary>
        /// Get rover's position.
        /// </summary>
        /// <returns> Rover's current position. </returns>
        public Position GetRoverPosition()
        {
            return position;
        }
    }
}
