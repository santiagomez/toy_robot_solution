using System;
using ToyRobot.Infrastructure;
using ToyRobot.Model;
using ToyRobot.Model.Builders;

namespace ToyRobot.Commands
{
    public class UserCommandPlace : UserCommand
    {
        private readonly IXYCoordinates _newCoordinates;
        private readonly MovingDirection _newDirection;

        public UserCommandPlace(int xCoordinate, int yCoordinate, MovingDirection direction)
        {
            var coordinatesBuilder = ServiceProvider.Instance.GetService<IXYCoordinatesBuilder>();

            _newCoordinates = coordinatesBuilder.WithXYCoordinate(xCoordinate, yCoordinate).Build();
            _newDirection = direction;
        }

        public override bool Execute(IGameContext gameContext)
        {
            if (gameContext == null)
                throw new ArgumentNullException(nameof(gameContext));

            return gameContext.RobotMover.Place(gameContext.Robot, gameContext.PlayingTable, _newCoordinates, _newDirection);
        }
    }
}