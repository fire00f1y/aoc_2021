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
            List<int> positions = new();
            var highest = 0;
            var lowest = int.MaxValue;
            ReadUtil.ReadAndProcessInput(line =>
            {
                foreach (var i in line.Split(",").Select(s => Convert.ToInt32(s)))
                {
                    if (i > highest)
                    {
                        highest = i;
                    }

                    if (i < lowest)
                    {
                        lowest = i;
                    }
                    positions.Add(i);
                }
            });
            
            var loss = int.MaxValue;
            var leastI = -1;
            for (var i = lowest; i <= highest; i++)
            {
                var l = Loss(positions, i);

                if (l >= loss) continue;
                loss = l;
                leastI = i;
            }
            
            Console.WriteLine($"Position {leastI} has least loss of {loss}.");
        }

        private static int Loss(List<int> positions, int target)
        {
            var sum = 0;
            foreach (var position in positions)
            {
                var diff = Math.Abs(position - target);
                sum += ((diff * diff) + diff) / 2;
            }

            return sum;
        }
    }
}