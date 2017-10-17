using System;
using ToyRobot.Infrastructure;
using ToyRobot.Model;
using ToyRobot.Model.Builders;

namespace ToyRobot.Utils
{
    public class RobotMover : IRobotMover
    {
        private readonly IXYCoordinatesBuilder _xyCoordinatesBuilder;

        public RobotMover()
        {
            var xyCoordinatesBuilder = ServiceProvider.Instance.GetService<IXYCoordinatesBuilder>();
            _xyCoordinatesBuilder = xyCoordinatesBuilder;
        }

        public bool Left(IRobot robot)
        {
            var success = true;

            switch (robot.CurrentFacingDirection)
            {
                case MovingDirection.NORTH:
                    robot.CurrentFacingDirection = MovingDirection.WEST;
                    break;
                case MovingDirection.WEST:
                    robot.CurrentFacingDirection = MovingDirection.SOUTH;
                    break;
                case MovingDirection.SOUTH:
                    robot.CurrentFacingDirection = MovingDirection.EAST;
                    break;
                case MovingDirection.EAST:
                    robot.CurrentFacingDirection = MovingDirection.NORTH;
                    break;
                default:
                    robot.CurrentFacingDirection = MovingDirection.NOTSET;
                    success = false;
                    break;
            }

            return success;
        }

        public bool Right(IRobot robot)
        {
            var success = true;

            switch (robot.CurrentFacingDirection)
            {
                case MovingDirection.NORTH:
                    robot.CurrentFacingDirection = MovingDirection.EAST;
                    break;
                case MovingDirection.EAST:
                    robot.CurrentFacingDirection = MovingDirection.SOUTH;
                    break;
                case MovingDirection.SOUTH:
                    robot.CurrentFacingDirection = MovingDirection.WEST;
                    break;
                case MovingDirection.WEST:
                    robot.CurrentFacingDirection = MovingDirection.NORTH;
                    break;
                default:
                    robot.CurrentFacingDirection = MovingDirection.NOTSET;
                    success = false;
                    break;
            }

            return success;
        }

        public bool Move(IRobot robot, IPlayingTable table)
        {
            if (robot == null)
                throw new ArgumentNullException(nameof(robot));

            if (table == null)
                throw new ArgumentNullException(nameof(table));

            // Ignore MOVE command if no coordinates have been set (i.e. robot has not been PLACEd)
            if (robot.CurrentCoordinates == null)
                return false;

            var newCoordinates = GetMoveCoordinates(robot);

            if (table.CanMoveToCoordinates(newCoordinates))
            {
                robot.CurrentCoordinates = newCoordinates;
                return true;
            }
            return false;
        }

        public bool Place(IRobot robot, IPlayingTable table, IXYCoordinates newCoordinates,
            MovingDirection newDirection)
        {
            if (robot == null)
                throw new ArgumentNullException(nameof(robot));

            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (newCoordinates == null)
                throw new ArgumentNullException(nameof(newCoordinates));

            if (newDirection == MovingDirection.NOTSET)
                throw new ArgumentNullException(nameof(newDirection));

            if (!table.CanMoveToCoordinates(newCoordinates))
                return false;

            table.RemoveRobot(robot);
            robot.CurrentCoordinates = newCoordinates;
            robot.CurrentFacingDirection = newDirection;

            return table.AddRobot(robot);
        }

        public IXYCoordinates GetMoveCoordinates(IRobot robot)
        {
            var incrementX = 0;
            var incrementY = 0;

            switch (robot.CurrentFacingDirection)
            {
                case MovingDirection.NORTH:
                    incrementY++;
                    break;
                case MovingDirection.SOUTH:
                    incrementY--;
                    break;
                case MovingDirection.EAST:
                    incrementX++;
                    break;
                case MovingDirection.WEST:
                    incrementX--;
                    break;
            }

            var newCoordinates = _xyCoordinatesBuilder.Instance()
                .WithXCoordinate(robot.CurrentCoordinates.X + incrementX)
                .WithYCoordinate(robot.CurrentCoordinates.Y + incrementY)
                .Build();

            return newCoordinates;
        }
    }
}