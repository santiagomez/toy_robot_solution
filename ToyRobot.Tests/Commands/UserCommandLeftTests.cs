using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Commands;
using ToyRobot.Model;
using ToyRobot.UI;
using ToyRobot.Utils;

namespace ToyRobot.Tests.Commands
{
    [TestClass]
    public class UserCommandLeftTests
    {
        private readonly UserCommandLeft _userCommand = new UserCommandLeft();

        [TestMethod]
        public void WhenGameContextIsNullThenArgumentNullExceptionIsThrown()
        {
            // Arrange
            IGameContext gameContext = null;

            // Act/Assert
            try
            {
                _userCommand.Execute(gameContext);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("gameContext"));
            }
        }

        [TestMethod]
        public void WhenGameContextIsValidThenExecuteCallsRobotMoverLeft()
        {
            // Arrange
            var robotMoverMock = new Mock<IRobotMover>();
            IGameContext gameContext = new GameContext
            {
                GameTerminated = false,
                RobotMover = robotMoverMock.Object
            };

            // Act
            var success = _userCommand.Execute(gameContext);

            // Assert
            robotMoverMock.Verify(x => x.Left(It.IsAny<IRobot>()), Times.Exactly(1));
        }
    }
}