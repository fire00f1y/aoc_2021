// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    internal static class Program
    {
        private static readonly List<int> Sums = new List<int>();

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

                if (!window.Ready())
                {
                    continue;
                }

                var sum = window.Sum();
                if (Sums.Count > 0)
                {
                    increased += Sums[^1] < sum ? 1 : 0;
                }
                Sums.Add(sum);
            }

            Console.WriteLine($"{increased} number of depth increases");
        }
    }
}