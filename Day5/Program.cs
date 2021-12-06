using System;
using System.Xml;
using Common;

namespace Advent
{
    internal static class Day5
    {
        private static void Main(string[] args)
        {
            int[,] grid = new int[1000, 1000];
            for (var y = 0; y < 1000; y++)
            {
                for (var x = 0; x < 1000; x++)
                {
                    grid[x, y] = 0;
                }
            }

            ReadUtil.ReadAndProcessInput(line =>
            {
                var coords = line.Split(" -> ");
                var start = coords[0];
                var end = coords[1];

                var x1 = Convert.ToInt32(start.Split(",")[0]);
                var x2 = Convert.ToInt32(end.Split(",")[0]);
                var y1 = Convert.ToInt32(start.Split(",")[1]);
                var y2 = Convert.ToInt32(end.Split(",")[1]);

                if (x1 == x2)
                {
                    var startY = y1 > y2 ? y2 : y1;
                    var endY = y1 > y2 ? y1 : y2;
                    for (var y = startY; y <= endY; y++)
                    {
                        grid[x1, y]++;
                    }
                } else if (y1 == y2)
                {
                    var startX = x1 > x2 ? x2 : x1;
                    var endX = x1 > x2 ? x1 : x2;
                    for (var x = startX; x <= endX; x++)
                    {
                        grid[x, y1]++;
                    }
                }
                else
                {
                    var startX = 0;
                    var startY = 0;
                    var endX = 0;
                    var endY = 0;
                    if (x1 < x2)
                    {
                        startX = x1;
                        startY = y1;
                        endX = x2;
                        endY = y2;
                    }
                    else
                    {
                        startX = x2;
                        startY = y2;
                        endX = x1;
                        endY = y1;
                    }

                    if (startY > endY)
                    {
                        var curY = startY;
                        for (var x = startX; x <= endX; x++)
                        {
                            grid[x, curY]++;
                            curY--;
                        }
                    }
                    else
                    {
                        var curY = startY;
                        for (var x = startX; x <= endX; x++)
                        {
                            grid[x, curY]++;
                            curY++;
                        }
                    }
                }
            });

            var count = 0;
            for (var y = 0; y < 1000; y++)
            {
                for (var x = 0; x < 1000; x++)
                {
                    if (grid[x, y] >= 2) count++;
                }
            }
            
            Console.WriteLine($"{count} points have at least 2 lines");
        }
    }
}