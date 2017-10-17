namespace ToyRobot.Model
{
    public interface IXYCoordinates
    {
        int X { get; set; }
        int Y { get; set; }

        string ToString();
    }
}