using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
using Microsoft.VisualBasic;

namespace Advent
{
    internal static class Day3
    {
        // Part 1
        private static void Main1(string[] args)
        {
            List<string> bytes = new List<string>();
            ReadUtil.ReadAndProcessInput(line => { bytes.Add(line); });

            var gamma = "";
            var bitCount = bytes[0].Length;
            var byteCount = bytes.Count;

            for (var i = 0; i < bitCount; i++)
            {
                if (SumColumn(bytes, i) > (byteCount / 2))
                {
                    gamma += "1";
                }
                else
                {
                    gamma += "0";
                }
            }

            var gammaValue = Convert.ToInt32(gamma, 2);
            var epsilonValue = Convert.ToInt32(InvertBits(gamma), 2);

            Console.WriteLine($"Gamma: {gamma}, Epsilon: {InvertBits(gamma)}. Product: {gammaValue * epsilonValue}");
        }

        // Part 2
        private static void Main(string[] args)
        {
            List<string> bytes = new List<string>();
            ReadUtil.ReadAndProcessInput(line => { bytes.Add(line); });

            List<string> oxygen = new(bytes);
            List<string> carbon = new(bytes);
            for (var i = 0; i < bytes[0].Length; i++)
            {
                if (oxygen.Count > 1)
                {
                    var bit = ModeBit(oxygen, i);
                    oxygen = WithBits(oxygen, i, bit);
                }

                if (carbon.Count > 1)
                {
                    var bit = ModeBit(carbon, i) == "1" ? "0" : "1";
                    carbon = WithBits(carbon, i, bit);
                }

                if (oxygen.Count == 1 && carbon.Count == 1)
                {
                    break;
                }
            }

            var o2 = Convert.ToInt32(oxygen[0], 2);
            var co2 = Convert.ToInt32(carbon[0], 2);

            Console.WriteLine($"Oxygen: {o2}, Carbon: {co2}, life support rating: {o2 * co2}");
        }

        private static List<string> WithBits(List<string> bytes, int col, string bit)
        {
            return bytes.FindAll(b => char.ToString(b[col]) == bit);
        }

        private static string ModeBit(IReadOnlyCollection<string> bytes, int col)
        {
            var zeros = bytes.Count(b => b[col] == '0');

            return zeros > bytes.Count / 2 ? "0" : "1";
        }

        private static int SumColumn(IEnumerable<string> bytes, int col)
        {
            return bytes.Sum(b => b[col] == '1' ? 1 : 0);
        }

        private static string InvertBits(string input)
        {
            return input.Aggregate("", (current, b) => current + (b == '0' ? '1' : '0'));
        }
    }
}