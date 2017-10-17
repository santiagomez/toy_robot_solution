namespace ToyRobot.Commands
{
    public abstract class UserCommand
    {
        public abstract bool Execute(IGameContext gameContext);
    }
}