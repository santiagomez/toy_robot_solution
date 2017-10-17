using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Commands;

namespace ToyRobot.Tests.Commands
{
    [TestClass]
    public class UserCommandFactoryTests
    {
        private readonly UserCommandFactory _factory = new UserCommandFactory();

        [TestMethod]
        public void WhenCommandIsLeftThenFactoryReturnsUserCommandLeft()
        {
            // Arrange
            var commandStr = "LEFT";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandLeft));
        }

        [TestMethod]
        public void WhenCommandIsRightThenFactoryReturnsUserCommandRight()
        {
            // Arrange
            var commandStr = "RIGHT";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandRight));
        }

        [TestMethod]
        public void WhenCommandIsMoveThenFactoryReturnsUserCommandMove()
        {
            // Arrange
            var commandStr = "MOVE";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandMove));
        }

        [TestMethod]
        public void WhenCommandIsPlaceThenFactoryReturnsUserCommandPlace()
        {
            // Arrange
            var commandStr = "PLACE 1,3,NORTH";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandPlace));
        }

        [TestMethod]
        public void WhenCommandIsPlaceWithInvalidArgumentsThenFactoryReturnsUserCommandIgnored()
        {
            // Arrange
            var commandStr = "PLACE 1,NORTH";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandIgnored));
        }

        [TestMethod]
        public void WhenCommandIsReportThenFactoryReturnsUserCommandReport()
        {
            // Arrange
            var commandStr = "REPORT";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandReport));
        }

        [TestMethod]
        public void WhenCommandIsExitThenFactoryReturnsUserCommandExit()
        {
            // Arrange
            var commandStr = "EXIT";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandExit));
        }

        [TestMethod]
        public void WhenCommandIsHelpThenFactoryReturnsUserCommandHelp()
        {
            // Arrange
            var commandStr = "HELP";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandHelp));
        }

        [TestMethod]
        public void WhenCommandIsInvalidThenFactoryReturnsUserCommandIgnored()
        {
            // Arrange
            var commandStr = "InvalidCommand123";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandIgnored));
        }

        [TestMethod]
        public void CommandFactoryIsCaseInsensitive()
        {
            // Arrange
            var commandStr = "LeFt";

            // Act
            var command = _factory.Create(commandStr);

            // Assert
            Assert.IsInstanceOfType(command, typeof(UserCommandLeft));
        }
    }
}