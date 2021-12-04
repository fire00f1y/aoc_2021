using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Advent
{
    public class Board
    {
        private int[,] numbers = new int[5, 5];
        bool[,] mask = new bool[5, 5];
        private Dictionary<string, List<int>> index = new();

        public Board(List<string> lines)
        {
            for (var y = 0; y < lines.Count; y++)
            {
                var nums = new List<string>(Strings.Split(lines[y])).Where(n => n != "").ToList();
                
                for (var x = 0; x < nums.Count; x++)
                {
                    var num = Convert.ToInt32(nums[x]);
                    numbers[x, y] = num;
                    if (index.ContainsKey(nums[x]))
                    {
                        index[nums[x]].Add(CoordToIndex(x, y));
                    }
                    else
                    {
                        var temp = new List<int>();
                        temp.Add(CoordToIndex(x, y));
                        index.Add(nums[x], temp);
                    }
                }
            }

            for (var y = 0; y < 5; y++)
            {
                for (var x = 0; x < 5; x++)
                {
                    mask[x, y] = false;
                }
            }
        }

        private int CoordToIndex(int x, int y)
        {
            return y * 5 + x;
        }

        private int XfromIndex(int i)
        {
            return i % 5;
        }

        private int YfromIndex(int i)
        {
            return i / 5;
        }

        public void Mark(string number)
        {
            var locations = index.ContainsKey(number) ? index[number] : new List<int>();
            if (locations.Count == 0)
            {
                return;
            }

            foreach (var location in locations)
            {
                var x = XfromIndex(location);
                var y = YfromIndex(location);

                mask[x, y] = true;
            }
        }

        public int SumUnmarked()
        {
            var sum = 0;
            for (var y = 0; y < 5; y++)
            {
                for (var x = 0; x < 5; x++)
                {
                    sum += mask[x, y] ? 0 : numbers[x, y];
                }
            }

            return sum;
        }

        public bool Bingo()
        {
            // check all horizontal win conditions
            bool complete;
            for (var y = 0; y < 5; y++)
            {
                complete = true;
                for (var x = 0; x < 5; x++)
                {
                    complete &= mask[x, y];
                }

                if (complete) 
                    return true;
            }

            // check all vertical win conditions
            for (var x = 0; x < 5; x++)
            {
                complete = true;
                for (var y = 0; y < 5; y++)
                {
                    complete &= mask[x, y];
                }

                if (complete) 
                    return true;
            }

            // // check diagonal win conditions
            // complete = true;
            // for (var i = 0; i < 5; i++)
            // {
            //     complete &= mask[i, i];
            // }
            //
            // if (complete) 
            //     return true;
            //
            // complete = true;
            // for (var i = 4; i >= 0; i--)
            // {
            //     complete &= mask[i, 4 - i];
            // }
            //
            // if (complete)
            //     return true;

            return false;
        }
    }
}