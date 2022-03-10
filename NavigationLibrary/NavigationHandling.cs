
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
    }
}
