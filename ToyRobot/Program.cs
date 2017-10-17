using System;
using System.Collections.Generic;

namespace ToyRobot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Toy Robot!");
            PlayGame(args);

            Console.WriteLine("Thank you for playing Toy Robot. Press any key to exit.");
            Console.ReadKey();
        }

        private static void PlayGame(IList<string> args)
        {
            ToyRobotGame.Instance().PlayGame(args);
        }
    }
}