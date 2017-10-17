using ToyRobot.Commands;
using ToyRobot.Model;
using ToyRobot.UI;
using ToyRobot.Utils;

namespace ToyRobot
{
    public interface IGameContext
    {
        IRobotMover RobotMover { get; }
        IPlayingTable PlayingTable { get; }
        IRobot Robot { get; }
        bool GameTerminated { get; set; }
        IUserInterface UserInterface { get; set; }
        void Initialize(IPlayingTable playingTable, IRobot robot, IRobotMover robotMover, IUserInterface userInterface, IUserCommandFactory userCommandFactory);

        void ExecuteCommand(string commandStr);
    }
}