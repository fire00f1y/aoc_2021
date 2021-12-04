using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Common;
using Microsoft.VisualBasic;

namespace Advent
{
    internal static class Day3
    {
        // Part 1
        private static void Main(string[] args)
        {
            List<string> numbers = new();
            List<Board> boards = new();
            List<string> batch = new();
            List<int> remaining = new();
            ReadUtil.ReadAndProcessInput(line =>
            {
                if (numbers.Count == 0)
                {
                    numbers = new List<string>(Strings.Split(line, ","));
                    return;
                }

                if (line is "" or " " or "\n") return;
                
                batch.Add(line);

                if (batch.Count != 5) return;
                remaining.Add(boards.Count);
                boards.Add(new Board(batch));
                batch = new List<string>();
            });
            
            foreach (var number in numbers)
            {
                foreach (var i in remaining)
                {
                    var board = boards[i];
                    board.Mark(number);
                    if (!board.Bingo()) continue;

                    remaining = remaining.Where(r => r != i).ToList();
                    if (remaining.Count != 0) continue;
                    
                    var num = Convert.ToInt32(number);
                    var sum = board.SumUnmarked();
                    Console.WriteLine($"Bingo on {num}! Score is {sum * num}");
                    System.Environment.Exit(0);
                }
            }
            
            Console.WriteLine("No winners found?");
        }
    }
}