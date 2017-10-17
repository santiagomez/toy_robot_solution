using System;
using System.Text;

namespace ToyRobot.Commands
{
    public class UserCommandHelp : UserCommand
    {
        public override bool Execute(IGameContext gameContext)
        {
            if (gameContext == null)
                throw new ArgumentNullException(nameof(gameContext));

            var sb = new StringBuilder();
            sb.AppendLine("The following are the available commands:");
            sb.AppendLine("    PLACE X, Y, F");
            sb.AppendLine(
                "        will put the toy robot on the table in position X,Y and facing (F) NORTH, SOUTH, EAST or WEST");
            sb.AppendLine("    MOVE");
            sb.AppendLine("        will move the toy robot one unit forward in the direction it is currently facing");
            sb.AppendLine("    LEFT");
            sb.AppendLine("    RIGHT");
            sb.AppendLine(
                "        will rotate the robot 90 degrees in the specified direction without changing the position of the robot.");
            sb.AppendLine("    REPORT");
            sb.AppendLine("        will announce the X,Y and F of the robot");
            sb.AppendLine("    EXIT");
            sb.AppendLine("        will exit the app.");
            gameContext.UserInterface.PrintMessage(sb.ToString());
            return true;
        }
    }
}