using System;
using System.Diagnostics;

namespace FatCat.Logging
{
    internal static class Global
    {
        public static string ApplicationName
        {
            get { return Process.GetCurrentProcess().ProcessName; }
        }

        public static string Path
        {
            get
            {
                return string.Format("{0}_log.txt", ApplicationName);
            }
        }
    }
}