// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        private static List<int> sums = new List<int>();

        static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead("input.txt"));
            var increased = 0;

            var window = new SlidingWindow(3);
            while (!reader.EndOfStream)
            {
                // Assuming no input is malformed
                var line = reader.ReadLine();
                var num = Convert.ToInt32(line);
                window.Add(num);

                if (!window.Summable())
                {
                    continue;
                }

                var sum = window.Sum();
                if (sums.Count > 0)
                {
                    increased += sums[^1] < sum ? 1 : 0;
                }
                sums.Add(sum);
            }

            Console.WriteLine($"{increased} number of depth increases");
        }
    }
}