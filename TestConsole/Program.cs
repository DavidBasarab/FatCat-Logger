using System;
using FatCat.Logger.Implementation;
using FatCat.Logger.Interface;

namespace TestConsole
{
    internal class Program
    {
        public static Type FatCatLoggerType { get; set; }

        private static void Main(string[] args)
        {
            FatCatLoggerType = Logger.Log.GetType();

            //var parameters = FatCatLoggerType.GetMethod("Message").GetParameters();

            //var haveMessageParameter = parameters
            //                               .Where(i => i.Name == "message" && i.ParameterType == typeof(string))
            //                               .Count() == 1;

            //var temp = FatCatLoggerType.GetEnumName()

            Type logLevelType = typeof(LogLevel);

            Type test = typeof (object[]);

            Type test2 = Type.GetType("int");
        }
    }
}