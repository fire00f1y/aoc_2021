
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

namespace Advent
{
    internal static class Day2
    {
        private static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead("input.txt"));
            var x = 0;
            var y = 0;
            var aim = 0;
            
            while (!reader.EndOfStream)
            {
                // Assuming no input is malformed
                var line = reader.ReadLine();
                var pieces = Strings.Split(line, " ", -1);
                var direction = pieces[0];
                var amount = Convert.ToInt32(pieces[1]);

                switch (direction)
                {
                    case "forward":
                        x += amount;
                        if (aim != 0)
                        {
                            y += aim * amount;
                        }
                        break;
                    case "down":
                        aim += amount;
                        break;
                    case "up":
                        aim -= amount;
                        break;
                    default:
                        Console.WriteLine($"Got non-standard direction: {direction}");
                        break;
                }
            }
            Console.WriteLine($"Final position is x: {x}, y: {y}. Combined: {x * y}");
        }
    }
}