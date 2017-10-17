using System;
using ToyRobot.Commands;
using ToyRobot.Infrastructure;
using ToyRobot.Model;
using ToyRobot.UI;
using ToyRobot.Utils;

namespace ToyRobot
{
    public class GameContext : IGameContext
    {
        private UserCommand _userCommand;
        private IUserCommandFactory _userCommandFactory;

        public void Initialize(IPlayingTable playingTable, IRobot robot, IRobotMover robotMover, IUserInterface userInterface, IUserCommandFactory userCommandFactory)
        {
            PlayingTable = playingTable;
            RobotMover = robotMover;
            Robot = robot;

            UserInterface = userInterface;
            _userCommandFactory = userCommandFactory;
        }

        public IRobotMover RobotMover { get; set; }
        public IPlayingTable PlayingTable { get; set; }
        public IRobot Robot { get; private set; }
        public bool GameTerminated { get; set; }
        public IUserInterface UserInterface { get; set; }

        public void ExecuteCommand(string commandStr)
        {
            _userCommand = _userCommandFactory.Create(commandStr);

            try
            {
                if (!_userCommand.Execute(this))
                    UserInterface.PrintMessage("Command failed.");
            }
            catch (Exception ex)
            {
                UserInterface.PrintMessage($"ERROR - {ex.Message}");
            }
        }
    }
}