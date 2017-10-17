using System;

namespace ToyRobot.Commands
{
    public class UserCommandIgnored : UserCommand
    {
        private readonly string _message;

        public UserCommandIgnored(string message = null)
        {
            _message = message;
        }

        public override bool Execute(IGameContext gameContext)
        {
            if (gameContext == null)
                throw new ArgumentNullException(nameof(gameContext));

            var message = string.IsNullOrWhiteSpace(_message)
                ? "Unrecognised command. Type HELP to read instructions or EXIT to exit the game."
                : _message;

            gameContext.UserInterface.PrintMessage(message);
            return false;
        }
    }
}