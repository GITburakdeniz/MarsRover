namespace NavigationLibrary
{
    public class PositionHandling
    {   
        public PositionHandling() { }
        public bool IsValidPosition(string? str)
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

        public bool IsValidDirection(string? str)
        {
            if (IsValidPosition(str))
            {
                string[] positions = str.Split(" ");
                if (positions.Length == 3 && new string[] { "N","S","W","E" }.Contains(positions[2]))
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool IsInBorder(Position position)
        {
            if (position.XCordinate < Plateau.GetInstance().LowerXCordinate || position.YCordinate < Plateau.GetInstance().LowerYCordinate)
                return false;

            if (position.XCordinate > Plateau.GetInstance().UpperXCordinate || position.YCordinate > Plateau.GetInstance().UpperYCordinate)
                return false;
            return true;
        }

        public Direction getCompassDirection(string compassDirection)
        {
                if (compassDirection == "E")
                    return Direction.East;
                else if (compassDirection == "W")
                    return Direction.West;
                else if (compassDirection == "N")
                    return Direction.North;
                else
                    return Direction.South;
        }

    }
}