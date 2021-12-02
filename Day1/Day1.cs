using System;
using System.Collections.Generic;
using Common;

namespace Advent
{
    internal static class Day1
    {
        private static readonly List<int> Sums = new List<int>();

        private static void Main(string[] args)
        {
            var increased = 0;

            var window = new SlidingWindow(3);
            ReadUtil.ReadAndProcessInput(line =>
            {
                var num = Convert.ToInt32(line);
                window.Add(num);

                if (!window.Ready())
                {
                    return;
                }

                var sum = window.Sum();
                if (Sums.Count > 0)
                {
                    increased += Sums[^1] < sum ? 1 : 0;
                }

                Sums.Add(sum);
            });

            Console.WriteLine($"{increased} number of depth increases");
        }
    }
}