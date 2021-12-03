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
        private static void Main(string[] args)
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

        private static int SumColumn(List<string> bytes, int col)
        {
            return bytes.Sum(b => b[col] == '1' ? 1 : 0);
        }

        private static string InvertBits(string input)
        {
            var inverse = "";
            for (var i = 0; i < input.Length; i++)
            {
                inverse += input[i] == '0' ? '1' : '0';
            }

            return inverse;
        }
    }
}