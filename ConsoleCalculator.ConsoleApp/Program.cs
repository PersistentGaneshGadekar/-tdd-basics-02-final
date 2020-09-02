using System;
using System.Diagnostics;

namespace ConsoleCalculator.App
{
    class Program
    {
        static void Main()
        {
            top:
            try
            {
                var calc = new Calculator();
                ConsoleKeyInfo key;
                Console.WriteLine("Press Ctrl + C to close the program.");
                while (IsKillSwitch(key = Console.ReadKey(true)) == false)
                {
                    Console.Clear();
                    Console.WriteLine(calc.SendKeyPress(key.KeyChar));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error Enter not allowed. Do you want to continue? y or n");
                string input = Console.ReadLine();
                if(input.Trim().ToLower() == "y" || input.Trim().ToLower() == "yes")
                {
                    Console.Clear();
                    goto top;
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private static bool IsKillSwitch(ConsoleKeyInfo key)
        {          
            return key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control;
        }
    }
}
