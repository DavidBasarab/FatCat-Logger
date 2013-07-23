using System;
using FatCat.Logging.Operations;

namespace FatCat.Logging
{
    public static class Logger
    {
        public static void Write(string message)
        {
            StartingOperation.Start();

            WriteOperation.Write(message);
        }
    }
}