using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Commands;
using ToyRobot.Infrastructure;
using ToyRobot.Model;
using ToyRobot.Model.Builders;
using ToyRobot.Utils;

namespace ToyRobot.Tests.Commands
{
    [TestClass]
    public class UserCommandPlaceTests
    {
        private UserCommandPlace _userCommand = new UserCommandPlace(1, 1, MovingDirection.EAST);

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
        public void WhenGameContextIsValidThenExecuteCallsRobotMoverPlace()
        {
            // Arrange
            var robotMoverMock = new Mock<IRobotMover>();
            var xyCoordinatesBuilder = new Mock<IXYCoordinatesBuilder>();
            
            var xyCoordinates = new XYCoordinates{X = 3, Y = 7};
            xyCoordinatesBuilder.Setup(x => x.Build()).Returns(xyCoordinates);

            ServiceProvider.Instance.Bind<IXYCoordinatesBuilder>(xyCoordinatesBuilder.Object);

            _userCommand = new UserCommandPlace(3, 7, MovingDirection.NORTH);

            IGameContext gameContext = new GameContext
            {
                GameTerminated = false,
                RobotMover = robotMoverMock.Object
            };

            // Act
            var success = _userCommand.Execute(gameContext);

            // Assert
            robotMoverMock.Verify(x => x.Place(It.IsAny<IRobot>(), It.IsAny<IPlayingTable>(), xyCoordinates, MovingDirection.NORTH), Times.Exactly(1));
        }
    }
}