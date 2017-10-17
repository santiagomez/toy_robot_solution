using System.Collections.Generic;

namespace ToyRobot
{
    public interface IGameContextFactory
    {
        IGameContext CreateGameContext(IList<string> args);
    }
}