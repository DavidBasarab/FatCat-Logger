using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatCat.Logger;

namespace TestConsole
{
    class Program
    {
        public static Type FatCatLoggerType { get; set; }

        static void Main(string[] args)
        {
            FatCatLoggerType = Logger.Log.GetType();

            var parameters = FatCatLoggerType.GetMethod("Message").GetParameters();

            var haveMessageParameter = parameters
                                           .Where(i => i.Name == "message" && i.ParameterType == typeof(string))
                                           .Count() == 1;

        }
    }
}
