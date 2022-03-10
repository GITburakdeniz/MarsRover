namespace NavigationLibrary
{
    public static class PositionHandling
    {
        public static bool IsValidBorder(this string? str)
        {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            string[] borders = str.Split(" ");

            if (borders.Length < 2 || borders.Length > 3)
                return false;

            if (Int64.TryParse(borders[0], out long xCor) && Int64.TryParse(borders[1], out long yCor))
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
            if (str.IsValidBorder())
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