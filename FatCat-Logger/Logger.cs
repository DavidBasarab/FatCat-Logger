using FatCat.Logger.Implementation;

namespace FatCat.Logger
{
    public static class Logger
    {
        private static Logging _log;

        public static Logging Log
        {
            get { return _log ?? (_log = new DefaultLogger()); }
            set { _log = value; }
        }
    }
}