using System;

namespace ToyRobot.UI
{
    public interface IUserInterface
    {
        void PrintMessage(string message);
        string GetUserInput();
    }

    public class ConsoleUserInterface : IUserInterface
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}