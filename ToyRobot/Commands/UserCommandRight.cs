using System;

namespace ToyRobot.Commands
{
    public class UserCommandRight : UserCommand
    {
        public override bool Execute(IGameContext gameContext)
        {
            if (gameContext == null)
                throw new ArgumentNullException(nameof(gameContext));

            return gameContext.RobotMover.Right(gameContext.Robot);
        }
    }
}