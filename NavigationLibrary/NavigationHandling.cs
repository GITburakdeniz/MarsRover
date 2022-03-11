using System.Text.RegularExpressions;

namespace NavigationLibrary
{
    public class NavigationHandling
    {
        private readonly List<Turn> navigationRoute;

        public NavigationHandling() { navigationRoute = new List<Turn>(); }

        public List<Turn> NavigationRoute { get { return navigationRoute; } }
        public void AddNewRoute(Turn turn) { navigationRoute.Add(turn); }

        public bool IsValidRoute( string? str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (Regex.IsMatch(str, @"^[LMR]+$"))
                return true;

            return false;
        }

        public void TurnLeft( Position position)
        {
            int currentDir = Convert.ToInt32(position.Direction);
            
            currentDir--;
            position.Direction = (Direction)currentDir;

            if (currentDir == -1)
                position.Direction = Direction.North;
        }

        public void TurnRight( Position position)
        {
            int currentDir = Convert.ToInt32(position.Direction);
            
            currentDir++;
            position.Direction = (Direction)currentDir;

            if (currentDir == (Convert.ToInt32(Direction.NumberOfDirection)))
                position.Direction = Direction.East;
        }

        public void MoveFoward( Position position)
        {
            long tempX, tempY;
            tempX = position.XCordinate;
            tempY = position.YCordinate;

            if (position.Direction == Direction.North)
                position.YCordinate++;
            if (position.Direction == Direction.East)
                position.XCordinate++;
            if (position.Direction == Direction.West)
                position.XCordinate--;
            if (position.Direction == Direction.South)
                position.YCordinate--;

            if (!position.IsInBorder())
            {
                position.XCordinate = tempX;
                position.YCordinate = tempY;
                position.IsStopped = true;
            }
        }
    }
}
