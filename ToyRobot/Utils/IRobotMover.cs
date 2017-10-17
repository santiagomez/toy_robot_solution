using ToyRobot.Model;

namespace ToyRobot.Utils
{
    public interface IRobotMover
    {
        bool Left(IRobot robot);
        bool Right(IRobot robot);
        bool Move(IRobot robot, IPlayingTable table);
        bool Place(IRobot robot, IPlayingTable table, IXYCoordinates newCoordinates, MovingDirection newDirection);
    }
}