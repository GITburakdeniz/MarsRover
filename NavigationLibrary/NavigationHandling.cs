
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

        public static Direction GetLeftDirection(this Direction direction)
        {
            int currentDir = Convert.ToInt32(direction);

            if (currentDir == 0)
                return Direction.North;

            currentDir--;
            return (Direction)currentDir;
        }

        public static Direction GetRightDirection(this Direction direction)
        {
            int currentDir = Convert.ToInt32(direction);

            if (currentDir == (Convert.ToInt32(Direction.NumberOfDirection)-1))
                return Direction.East;

            currentDir++;
            return (Direction)currentDir;
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
