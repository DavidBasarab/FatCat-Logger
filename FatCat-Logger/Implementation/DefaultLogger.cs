using System;

namespace FatCat.Logger.Implementation
{
    internal class DefaultLogger : Logging
    {
        public void Message(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Exception(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void EventViewer(int eventViewerId, string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}