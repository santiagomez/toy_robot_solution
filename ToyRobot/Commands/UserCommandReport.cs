using System;

namespace ToyRobot.Commands
{
    public class UserCommandReport : UserCommand
    {
        public override bool Execute(IGameContext gameContext)
        {
            if (gameContext == null)
                throw new ArgumentNullException(nameof(gameContext));

            var message = gameContext.Robot.CurrentCoordinates == null
                ? $"Robot is not currently on the table. Use the {CommandType.PLACE.ToString()} command."
                : $"> {gameContext.Robot.CurrentCoordinates.X},{gameContext.Robot.CurrentCoordinates.Y},{gameContext.Robot.CurrentFacingDirection.ToString()}";

            gameContext.UserInterface.PrintMessage(message);
            return true;
        }
    }
}