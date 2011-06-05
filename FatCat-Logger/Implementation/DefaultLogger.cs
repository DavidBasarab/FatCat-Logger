using System;
using FatCat.Logger.Interface;

namespace FatCat.Logger.Implementation
{
    internal class DefaultLogger : Logging
    {
        public void Message(LogLevel level, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Exception(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void EventViewer(int eventViewerId, LogLevel level, string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}