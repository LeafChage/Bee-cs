using System;
using System.IO;

namespace Bee
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteAll(string message)
        {
            File.WriteAllText("./t.json", message);
        }
    }
}
