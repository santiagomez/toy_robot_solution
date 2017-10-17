using System.Collections.Generic;
using System.Reflection;
using ToyRobot.Commands;
using ToyRobot.Infrastructure;
using ToyRobot.Model;
using ToyRobot.Model.Builders;
using ToyRobot.UI;
using ToyRobot.Utils;

namespace ToyRobot
{
    public class GameContextFactory : IGameContextFactory
    {
        private IUserInterface _userInterface;

        public IGameContext CreateGameContext(IList<string> args)
        {
            _userInterface = ServiceProvider.Instance.GetService<IUserInterface>();

            GetTableDimensions(args, out var xDimension, out var yDimension);

            // Get new Table, robot and robot mover
            var playingTable = ServiceProvider.Instance.GetService<IPlayingTableBuilder>()
                .WithXDimension(xDimension)
                .WithYDimension(yDimension)
                .Build();

            var robot = ServiceProvider.Instance.GetService<IRobot>();
            var robotMover = ServiceProvider.Instance.GetService<IRobotMover>();

            var gameContext = ServiceProvider.Instance.GetService<IGameContext>();
            var userCommandFactory = ServiceProvider.Instance.GetService<IUserCommandFactory>();

            gameContext.Initialize(playingTable, robot, robotMover, _userInterface, userCommandFactory);

            return gameContext;
        }

        private void GetTableDimensions(IList<string> args, out int xDimension, out int yDimension)
        {
            xDimension = 5;
            yDimension = 5;

            if (args.Count >= 2)
            {
                if (!int.TryParse(args[0], out xDimension)
                    || !int.TryParse(args[1], out yDimension))
                    _userInterface.PrintMessage(
                        $"Invalid arguments. Only (x, y) dimensions for the table can be passed as arguments to override the default table size. i.e. '{Assembly.GetEntryAssembly().GetName()} 4 4' to start the game on a 4x4 table.");
            }
        }
    }
}