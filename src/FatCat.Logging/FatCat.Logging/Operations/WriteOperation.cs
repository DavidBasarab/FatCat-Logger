using System.IO;

namespace FatCat.Logging.Operations
{
    internal class WriteOperation
    {
        public static void Write(string message)
        {
            using (var writer = new StreamWriter(File.OpenWrite(Global.Path)))
                writer.Write(message);
        }
    }
}