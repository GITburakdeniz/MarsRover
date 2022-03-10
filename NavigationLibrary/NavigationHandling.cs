
using System.Text.RegularExpressions;

namespace NavigationLibrary
{
    public static class NavigationHandling
    {
        public static bool IsValidTurn(this string? str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (Regex.IsMatch(str, @"^[LMR]+$"))
                return true;

            return false;
        }

        public static void TurnLeft(this Position position)
        {
            int currentDir = Convert.ToInt32(position.Direction);
            
            currentDir--;
            position.Direction = (Direction)currentDir;

            if (currentDir == -1)
                position.Direction = Direction.North;
        }

        public static void TurnRight(this Position position)
        {
            int currentDir = Convert.ToInt32(position.Direction);
            
            currentDir++;
            position.Direction = (Direction)currentDir;

            if (currentDir == (Convert.ToInt32(Direction.NumberOfDirection)))
                position.Direction = Direction.East;
        }

        public static void MoveFoward(this Position position)
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
