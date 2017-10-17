using System;

namespace ToyRobot.Commands
{
    public class UserCommandLeft : UserCommand
    {
        public override bool Execute(IGameContext gameContext)
        {
            if (gameContext == null)
                throw new ArgumentNullException(nameof(gameContext));

            return gameContext != null
                   && gameContext.RobotMover.Left(gameContext.Robot);
        }
    }
}