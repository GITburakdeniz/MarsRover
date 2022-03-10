
namespace NavigationLibrary
{
    public sealed class Plateau
    {
        private int LowerXCor;
        private int LowerYCor;
        private int UpperXCor;
        private int UpperYCor;

        private Plateau() { }
        private static Plateau? instance = null;
        public static Plateau? GetInstance()
        {   
            if (instance == null)   
                instance = new Plateau();
            return instance;
        }

        public int LowerXCordinate 
        { 
            set { LowerXCor = value; }
            get { return LowerXCor; }
        }

        public int LowerYCordinate
        {
            set { LowerYCor = value; }
            get { return LowerYCor; }
        }

        public int UpperXCordinate
        {
            set{ UpperXCor = value; }
            get { return UpperXCor; }
        }

        public int UpperYCordinate
        {
            set { UpperYCor = value; }
            get { return UpperYCor; }
        }
    }
}
