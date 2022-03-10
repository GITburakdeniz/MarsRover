
namespace NavigationLibrary
{
    public class Position
    {
        private long xCor;
        private long yCor;
        private Direction direction;

        public Position(long xCor, long yCor, Direction direction)
        {
            this.xCor = xCor;   
            this.yCor = yCor;
            this.direction = direction;
        }

        public long XCordinate 
        {
            get { return xCor; } 
            set { xCor = value; } 
        }

        public long YCordinate
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
