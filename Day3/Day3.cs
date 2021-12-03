using System;
using System.Collections.Generic;
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

            int[] counts0 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int[] counts1 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            foreach (var b in bytes)
            {
                for (var i = 0; i < b.Length; i++)
                {
                    if (b[i] == '0')
                    {
                        counts0[i]++;
                    }
                    else
                    {
                        counts1[i]++;
                    }
                }
            }

            var gamma = "";
            var epsilon = "";

            for (var i = 0; i < counts0.Length; i++)
            {
                if (counts0[i] == counts1[i]) {Console.WriteLine($"{i} has equal number of 1s and 0s");}
                if (counts0[i] > counts1[i])
                {
                    gamma += "0";
                    epsilon += "1";
                }
                else
                {
                    gamma += "1";
                    epsilon += "0";
                }
            }

            var gammaValue = Convert.ToInt32(gamma, 2);
            var epsilonValue = Convert.ToInt32(epsilon, 2);

            Console.WriteLine($"Gamma: {gamma}, Epsilon: {epsilon}. Product: {gammaValue * epsilonValue}");
        }
    }
}