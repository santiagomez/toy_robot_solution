namespace ToyRobot.Model.Builders
{
    public class XYCoordinatesBuilder : IXYCoordinatesBuilder
    {
        private int _x = int.MinValue;
        private int _y = int.MinValue;

        public IXYCoordinatesBuilder Instance()
        {
            return new XYCoordinatesBuilder();
        }

        public IXYCoordinatesBuilder WithXCoordinate(int x)
        {
            _x = x;
            return this;
        }

        public IXYCoordinatesBuilder WithYCoordinate(int y)
        {
            _y = y;
            return this;
        }

        public IXYCoordinatesBuilder WithXYCoordinate(int x, int y)
        {
            _x = x;
            _y = y;
            return this;
        }

        public IXYCoordinates Build()
        {
            return new XYCoordinates
            {
                X = _x,
                Y = _y
            };
        }
    }
}