// See https://aka.ms/new-console-template for more information

using System;
using System.Linq.Expressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = 0;
            var num2 = 0;

            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("-----------------------\n");

            Console.WriteLine("Type a number, and then press Enter");
            num1 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Type another number, and then press Enter");
            num2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            Loop:
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Your result: {num1} + {num2} = {num1 + num2}");
                    break;
                case "s":
                    Console.WriteLine($"Your result: {num1} - {num2} = {num1 - num2}");
                    break;
                case "m":
                    Console.WriteLine($"Your result: {num1} * {num2} = {num1 * num2}");
                    break;
                case "d":
                    Console.WriteLine($"Your result: {num1} / {num2} = {num1 / num2}");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    goto Loop;
            }
            
            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();
        }
    }
}