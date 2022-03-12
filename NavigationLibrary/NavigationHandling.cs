using System.Text.RegularExpressions;

namespace NavigationLibrary
{
    /// <summary>
    /// Navigation system for navigating a mars rover.
    /// </summary>
    public class NavigationHandling
    {
        private readonly List<Turn> navigationRoute;

        public NavigationHandling() { navigationRoute = new List<Turn>(); }

        public List<Turn> NavigationRoute { get { return navigationRoute; } }
        public void AddNewRoute(Turn turn) { navigationRoute.Add(turn); }

        /// <summary>
        /// Validates given route string which is contains valid letter or not.
        /// </summary>
        /// <param name="exploreRoute">exploration route of the Rover</param>
        /// <returns> True or False </returns>
        public bool IsValidRoute( string? exploreRoute)
        {
            if (string.IsNullOrWhiteSpace(exploreRoute))
                return false;

            if (Regex.IsMatch(exploreRoute, @"^[LMR]+$"))
                return true;

            return false;
        }

        /// <summary>
        /// Turns the rover left direction
        /// </summary>
        /// <param name="position">position object of the rover</param>
        /// <returns> No returns </returns>
        public void TurnLeft( Position position)
        {
            int currentDir = Convert.ToInt32(position.Direction);
            
            currentDir--;
            position.Direction = (Direction)currentDir;

            if (currentDir == -1)
                position.Direction = Direction.North;

            if (position.IsStopped)
                position.IsStopped = false;
        }

        /// <summary>
        /// Turns the rover right direction
        /// </summary>
        /// <param name="position">position object of the rover</param>
        /// <returns> No returns </returns>
        public void TurnRight( Position position)
        {
            int currentDir = Convert.ToInt32(position.Direction);
            
            currentDir++;
            position.Direction = (Direction)currentDir;

            if (currentDir == (Convert.ToInt32(Direction.NumberOfDirection)))
                position.Direction = Direction.East;
            
            if (position.IsStopped)
                position.IsStopped = false;

        }

        /// <summary>
        /// Move forward the rover. If the rover reaches the plateau border, stop the rover and wait until it can move.
        /// </summary>
        /// <param name="position">position object of the rover</param>
        /// <returns> No returns </returns>
        public void MoveFoward( Position position)
        {
            long tempX, tempY;
            tempX = position.XCordinate;
            tempY = position.YCordinate;
            PositionHandling checkPosition = new PositionHandling();

            if (position.Direction == Direction.North)
                position.YCordinate++;
            if (position.Direction == Direction.East)
                position.XCordinate++;
            if (position.Direction == Direction.West)
                position.XCordinate--;
            if (position.Direction == Direction.South)
                position.YCordinate--;

            if (!checkPosition.IsInBorder(position)) 
            {
                position.XCordinate = tempX;
                position.YCordinate = tempY;
                position.IsStopped = true;  
            }

            position.CompassDirectionSymbol = checkPosition.getCompassSymbolDirection(position.Direction);
        }
    }
}
