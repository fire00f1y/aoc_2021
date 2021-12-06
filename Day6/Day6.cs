using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Advent
{
    internal static class Day6
    {
        private static void Main(string[] args)
        {
            List<int> fishies = new(); 
            ReadUtil.ReadAndProcessInput(line =>
            {
                fishies.AddRange(line.Split(",").Select(fish => Convert.ToInt32(fish)));
            });

            Console.WriteLine($"Initial state: {string.Join(",", fishies)}");
            for (var day = 1; day <= 256; day++)
            {
                for (var i = fishies.Count -1; i >= 0; i--)
                {
                    var cur = fishies[i];
                    cur--;
                    if (cur < 0)
                    {
                        cur = 6;
                        fishies.Add(8);
                    }

                    fishies[i] = cur;
                }
                Console.WriteLine($"{day}");
            }
            Console.WriteLine($"Finished with {fishies.Count} fish.");
        }
    }
}
            