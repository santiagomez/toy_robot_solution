using ToyRobot.Infrastructure;

namespace ToyRobot.Model.Builders
{
    public static class ZeroZeroXYCoordinatesBuilder
    {
        public static IXYCoordinates Build()
        {
            var xyCoordinatesBuilder = ServiceProvider.Instance.GetService<IXYCoordinatesBuilder>();
            return xyCoordinatesBuilder.WithXYCoordinate(0, 0).Build();
        }
    }
}