namespace ToyRobot.Model
{
    public class XYCoordinates : IXYCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object obj)
        {
            return obj is IXYCoordinates xyCoordinates && Equals(xyCoordinates);
        }

        public bool Equals(IXYCoordinates xyCoordinates)
        {
            return xyCoordinates.X == X
                   && xyCoordinates.Y == Y;
        }

        public override int GetHashCode()
        {
            return 17 * 37 * X.GetHashCode() * Y.GetHashCode();
        }
    }
}