namespace ToyRobot.Model.Builders
{
    public class PlayingTableBuilder : IPlayingTableBuilder
    {
        private IXYCoordinates _rootCoordinates = ZeroZeroXYCoordinatesBuilder.Build();
        private int _xDimension = 5;
        private int _yDimension = 5;

        public IPlayingTableBuilder WithRoot(IXYCoordinates rootCoordinates)
        {
            _rootCoordinates = rootCoordinates;
            return this;
        }

        public IPlayingTableBuilder WithXDimension(int xDimension)
        {
            _xDimension = xDimension;
            return this;
        }

        public IPlayingTableBuilder WithYDimension(int yDimension)
        {
            _yDimension = yDimension;
            return this;
        }

        public IPlayingTable Build()
        {
            return new PlayingTable
            {
                Root = _rootCoordinates,
                XDimensions = _xDimension,
                YDimensions = _yDimension
            };
        }
    }
}