
namespace NavigationLibrary
{
    public class Position
    {
        private long xCor;
        private long yCor;
        private Direction direction;
        private bool isStopped;
        private string compassDirectionSymbol;

        public Position(long xCor, long yCor, Direction direction)
        {
            this.xCor = xCor;   
            this.yCor = yCor;
            this.direction = direction;
            isStopped = false;
            compassDirectionSymbol = "";
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

        public bool IsStopped
        {
            get { return isStopped; }
            set { isStopped = value; }
        }

        public string CompassDirectionSymbol
        {
            get { return compassDirectionSymbol; }
            set { compassDirectionSymbol = value; }
        }
    }
}
