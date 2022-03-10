
namespace NavigationLibrary
{
    public class Position
    {
        private int xCor;
        private int yCor;
        private Direction direction;

        public Position(int xCor, int yCor, Direction direction)
        {
            this.xCor = xCor;   
            this.yCor = yCor;
            this.direction = direction;
        }

        public int XCordinate 
        {
            get { return xCor; } 
            set { xCor = value; } 
        }

        public int YCordinate
        {
            get { return yCor; }
            set { yCor = value; }
        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}
