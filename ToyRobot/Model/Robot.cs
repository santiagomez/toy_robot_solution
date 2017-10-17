namespace ToyRobot.Model
{
    public interface IRobot
    {
        IXYCoordinates CurrentCoordinates { get; set; }
        MovingDirection CurrentFacingDirection { get; set; }
    }

    public class Robot : IRobot
    {
        public IXYCoordinates CurrentCoordinates { get; set; }
        public MovingDirection CurrentFacingDirection { get; set; }
    }
}