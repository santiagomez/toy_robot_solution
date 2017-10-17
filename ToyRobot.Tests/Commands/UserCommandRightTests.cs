using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Commands;
using ToyRobot.Model;
using ToyRobot.Utils;

namespace ToyRobot.Tests.Commands
{
    [TestClass]
    public class UserCommandRightTests
    {
        private readonly UserCommandRight _userCommand = new UserCommandRight();

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
        public void WhenGameContextIsValidThenExecuteCallsRobotMoverRight()
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
            robotMoverMock.Verify(x => x.Right(It.IsAny<IRobot>()), Times.Exactly(1));
        }
    }
}