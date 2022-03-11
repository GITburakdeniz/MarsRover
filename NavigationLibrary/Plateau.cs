
namespace NavigationLibrary
{
    public sealed class Plateau
    {
        private long LowerXCor;
        private long LowerYCor;
        private long UpperXCor;
        private long UpperYCor;

        private Plateau() {
            LowerXCor = 0;
            LowerYCor = 0;
        }
        private static Plateau? instance = null;
        public static Plateau? GetInstance()
        {   
            if (instance == null)   
                instance = new Plateau();
            return instance;
        }

        public long LowerXCordinate 
        { 
            set { LowerXCor = value; }
            get { return LowerXCor; }
        }

        public long LowerYCordinate
        {
            set { LowerYCor = value; }
            get { return LowerYCor; }
        }

        public long UpperXCordinate
        {
            set{ UpperXCor = value; }
            get { return UpperXCor; }
        }

        public long UpperYCordinate
        {
            set { UpperYCor = value; }
            get { return UpperYCor; }
        }
    }
}
