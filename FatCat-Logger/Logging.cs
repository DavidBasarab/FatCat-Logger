using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatCat.Logger
{
    public interface Logging
    {
        void Message(string message, params object[] args);
    }
}
