namespace NavigationLibrary
{
    public static class PositionHandling
    {
        public static bool IsValidPosition(this string? str)
        {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            string[] positions = str.Split(" ");

            if (positions.Length < 2 || positions.Length > 3)
                return false;

            if (Int64.TryParse(positions[0], out long xCor) && Int64.TryParse(positions[1], out long yCor))
            {
                if (xCor >= 0 && yCor >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidDirection(this string? str)
        {
            if (str.IsValidPosition())
            {
                string[] positions = str.Split(" ");
                if (positions.Length == 3 && new string[] { "N","S","W","E" }.Contains(positions[2]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}