using System;

namespace FatCat.Logger
{
    public interface Logging
    {
        void Message(string message, params object[] args);

        void Exception(Exception ex);

        void EventViewer(int eventViewerId, string message, params object[] args);
    }
}