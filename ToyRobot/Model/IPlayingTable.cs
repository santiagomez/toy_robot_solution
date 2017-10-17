namespace ToyRobot.Model
{
    public interface IPlayingTable
    {
        int XDimensions { get; set; }
        int YDimensions { get; set; }
        IXYCoordinates Root { get; set; }
        bool CanMoveToCoordinates(IXYCoordinates xyCoordinates);
        bool AddRobot(IRobot robot);
        void RemoveRobot(IRobot robot);
    }
}