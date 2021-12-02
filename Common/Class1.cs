using System;
using System.IO;

namespace Common
{
    public static class ReadUtil
    {
        public static void ReadAndProcessInput(Action<string> processFunc)
        {
            var reader = new StreamReader(File.OpenRead("input.txt"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Null input received");
                    continue;
                }

                processFunc(line);
            }

            reader.Close();
        }
    }
}