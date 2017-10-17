using System.Collections.Generic;
using System.Linq;

namespace ToyRobot.Model
{
    public class PlayingTable : IPlayingTable
    {
        public PlayingTable()
        {
            RobotsOnTable = new List<IRobot>();
        }

        public IList<IRobot> RobotsOnTable { get; }

        public int XDimensions { get; set; }
        public int YDimensions { get; set; }
        public IXYCoordinates Root { get; set; }

        public bool AddRobot(IRobot robot)
        {
            if (!CanMoveToCoordinates(robot.CurrentCoordinates))
                return false;

            RobotsOnTable.Add(robot);
            return true;
        }

        public void RemoveRobot(IRobot robot)
        {
            RobotsOnTable.Remove(robot);
        }

        public bool CanMoveToCoordinates(IXYCoordinates xyCoordinates)
        {
            return !RobotsOnTable.Any(r => r.CurrentCoordinates.Equals(xyCoordinates)) && Root.X <= xyCoordinates.X &&
                   xyCoordinates.X <= Root.X + XDimensions && Root.Y <= xyCoordinates.Y &&
                   xyCoordinates.Y <= Root.Y + YDimensions;
        }
    }
}