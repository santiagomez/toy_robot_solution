using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.Model;

namespace ToyRobot.Commands
{
    public class UserCommandFactory : IUserCommandFactory
    {
        public UserCommand Create(string commandStr)
        {
            string[] args = commandStr.Split(' ');

            var commandType = Enum.TryParse(args[0], true, out CommandType outCommandType)
                ? outCommandType
                : CommandType.UNKNOWN;

            switch (commandType)
            {
                case CommandType.LEFT:
                    return new UserCommandLeft();
                case CommandType.RIGHT:
                    return new UserCommandRight();
                case CommandType.MOVE:
                    return new UserCommandMove();
                case CommandType.PLACE:
                    return CreateUserCommandPlace(commandStr);
                case CommandType.REPORT:
                    return new UserCommandReport();
                case CommandType.HELP:
                    return new UserCommandHelp();
                case CommandType.EXIT:
                    return new UserCommandExit();
                default:
                    return new UserCommandIgnored();
            }
        }

        private static UserCommand CreateUserCommandPlace(string command)
        {
            var commandArgs = command.Split(' ').ToList();

            var errMessage =
                $"Invalid parameters for {CommandType.PLACE.ToString()} command. Coordinates and Direction are needed. i.e. to place in coordinates 1, 4 facing north use command 'PLACE 1,4,NORTH'";

            if (commandArgs.Count != 2)
            {
                return new UserCommandIgnored(errMessage);
            }

            var args = commandArgs[1].Split(',').ToList();

            if (args.Count < 3
                || !int.TryParse(args[0], out var xCoordinate)
                || !int.TryParse(args[1], out var yCoordinate)
                || !Enum.TryParse(args[2], true, out MovingDirection direction)
            )
            {
                return new UserCommandIgnored(errMessage);
            }

            return new UserCommandPlace(xCoordinate, yCoordinate, direction);
        }
    }
}