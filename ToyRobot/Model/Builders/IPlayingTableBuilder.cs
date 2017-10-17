namespace ToyRobot.Model.Builders
{
    public interface IPlayingTableBuilder
    {
        IPlayingTableBuilder WithRoot(IXYCoordinates rootCoordinates);
        IPlayingTableBuilder WithXDimension(int xDimension);
        IPlayingTableBuilder WithYDimension(int yDimension);
        IPlayingTable Build();
    }
}