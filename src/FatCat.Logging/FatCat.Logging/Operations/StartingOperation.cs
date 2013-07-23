using System.IO;

namespace FatCat.Logging.Operations
{
    internal class StartingOperation
    {
        public static void Start()
        {
            using (var stream = File.Create(Global.Path))
                stream.Close();
        }
    }
}