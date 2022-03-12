namespace NavigationLibrary
{
    public class PositionHandling
    {
        /// <summary>
        /// Position handling for navigating a mars rover.
        /// </summary>
        public PositionHandling() { }

        /// <summary>
        /// Validates given position string which must contains valid length and value.
        /// </summary>
        /// <param name="positionString">position of the Rover</param>
        /// <returns> True or False </returns>
        public bool IsValidPosition(string? positionString)
        {

            if (string.IsNullOrWhiteSpace(positionString))
                return false;

            string[] positions = positionString.Split(" ");

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

        /// <summary>
        /// Validates given direction string which must contains valid direction
        /// </summary>
        /// <param name="positionString">position of the Rover</param>
        /// <returns> True or False </returns>
        public bool IsValidDirection(string? positionString)
        {
            if (IsValidPosition(positionString))
            {
                string[] positions = positionString.Split(" ");
                if (positions.Length == 3 && new string[] { "N","S","W","E" }.Contains(positions[2]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks given position is in the plateau border or not.
        /// </summary>
        /// <param name="position">position object of the Rover</param>
        /// <returns> True or False </returns>
        public bool IsInBorder(Position position)
        {
            if (position.XCordinate < Plateau.GetInstance().LowerXCordinate || position.YCordinate < Plateau.GetInstance().LowerYCordinate)
                return false;

            if (position.XCordinate > Plateau.GetInstance().UpperXCordinate || position.YCordinate > Plateau.GetInstance().UpperYCordinate)
                return false;
            return true;
        }

        /// <summary>
        /// converts compass direction symbol to enum and returns it.
        /// </summary>
        /// <param name="compassDirection">current compass Direction of the Rover</param>
        /// <returns> Direction enumeration of the rover </returns>
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

        /// <summary>
        /// converts compass direction enumeration to symbol and returns it.
        /// </summary>
        /// <param name="compassDirection">current compass Direction of the Rover</param>
        /// <returns>  Compass direction symbol of the rover </returns>
        public string getCompassSymbolDirection(Direction compassDirection)
        {
            if (compassDirection == Direction.North)
                return "N";
            if (compassDirection == Direction.East)
                return "E";
            if (compassDirection == Direction.West)
                return "W";
            else
                return "S";
        }

    }
}