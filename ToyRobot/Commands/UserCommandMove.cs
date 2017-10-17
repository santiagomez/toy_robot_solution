namespace ToyRobot.Commands
{
    public class UserCommandMove : UserCommand
    {
        public override bool Execute(IGameContext gameContext)
        {
            var moved = gameContext != null
                        && gameContext.RobotMover.Move(gameContext.Robot, gameContext.PlayingTable);

            if (moved)
                gameContext.UserInterface.PrintMessage(
                    $"Moved to {gameContext.Robot.CurrentCoordinates.ToString()} facing {gameContext.Robot.CurrentFacingDirection.ToString()}");

            return moved;
        }
    }
}