namespace ToyRobot.Commands
{
    public interface IUserCommandFactory
    {
        UserCommand Create(string commandStr);
    }
}