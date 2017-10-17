namespace ToyRobot.Model.Builders
{
    public interface IXYCoordinatesBuilder
    {
        IXYCoordinatesBuilder Instance();
        IXYCoordinatesBuilder WithXCoordinate(int x);
        IXYCoordinatesBuilder WithYCoordinate(int y);
        IXYCoordinatesBuilder WithXYCoordinate(int x, int y);
        IXYCoordinates Build();
    }
}