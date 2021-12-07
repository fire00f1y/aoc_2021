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
            Dictionary<Int64, Int64> fishyCounts = new();
            for (var i = 0; i <= 8; i++)
            {
                fishyCounts.Add(i, 0);
            }
            
            ReadUtil.ReadAndProcessInput(line =>
            {
                foreach (var fish in line.Split(","))
                {
                    fishyCounts[Convert.ToInt64(fish)]++;
                }
            });
            
            for (var day = 1; day <= 256; day++)
            {
                var temp0 = fishyCounts[0];
                fishyCounts[0] = fishyCounts[1];
                fishyCounts[1] = fishyCounts[2];
                fishyCounts[2] = fishyCounts[3];
                fishyCounts[3] = fishyCounts[4];
                fishyCounts[4] = fishyCounts[5];
                fishyCounts[5] = fishyCounts[6];
                fishyCounts[6] = fishyCounts[7] + temp0;
                fishyCounts[7] = fishyCounts[8];
                fishyCounts[8] = temp0;
            }

            Int64 total = fishyCounts.Sum(entry => entry.Value);
            Console.WriteLine($"0: {fishyCounts[0]}, 1: {fishyCounts[1]}, 2: {fishyCounts[2]}, 3: {fishyCounts[3]}, 4: {fishyCounts[4]}, 5: {fishyCounts[5]}, 6: {fishyCounts[6]}, 7: {fishyCounts[7]}, 8: {fishyCounts[8]}, total: {total}");
            
        }
    }
}
            