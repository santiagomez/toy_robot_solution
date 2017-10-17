using System;

namespace ToyRobot.Commands
{
    public class UserCommandExit : UserCommand
    {
        public override bool Execute(IGameContext gameContext)
        {
            if (gameContext == null)
                throw new ArgumentNullException(nameof(gameContext));

            gameContext.GameTerminated = true;
            return true;
        }
    }
}