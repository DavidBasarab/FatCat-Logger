using System;

namespace FatCat.Logger.Interface
{
    public interface Logging
    {
        void Message(LogLevel level, string message, params object[] args);

        void Exception(Exception ex);

        void EventViewer(int eventViewerId, LogLevel level, string message, params object[] args);
    }
}