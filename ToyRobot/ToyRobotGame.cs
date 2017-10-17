using System.Collections.Generic;
using ToyRobot.Infrastructure;
using ToyRobot.UI;

namespace ToyRobot
{
    public class ToyRobotGame
    {
        private readonly IUserInterface _userInterface;
        private readonly IGameContextFactory _gameContextFactory;

        private ToyRobotGame()
        {
            _userInterface = ServiceProvider.Instance.GetService<IUserInterface>();
            _gameContextFactory = ServiceProvider.Instance.GetService<IGameContextFactory>();
        }

        public static ToyRobotGame Instance()
        {
            return new ToyRobotGame();
        }

        public void PlayGame(IList<string> args)
        {
            var gameContext = _gameContextFactory.CreateGameContext(args);

            while (!gameContext.GameTerminated)
            {
                gameContext.UserInterface.PrintMessage("Enter a command (type HELP for instructions): ");
                var userCommand = _userInterface.GetUserInput();
                gameContext.ExecuteCommand(userCommand);
            }
        }
    }
}