using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Commands;
using ToyRobot.UI;

namespace ToyRobot.Tests.Commands
{
    [TestClass]
    public class UserCommandHelpTests
    {
        private readonly UserCommandHelp _userCommand = new UserCommandHelp();

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
        public void WhenGameContextIsValidThenExecutePrintsAMessageInUI()
        {
            // Arrange
            var userInterfaceMock = new Mock<IUserInterface>();
            
            IGameContext gameContext = new GameContext
            {
                GameTerminated = false,
                UserInterface = userInterfaceMock.Object
            };

            // Act
            var success = _userCommand.Execute(gameContext);

            // Assert
            userInterfaceMock.Verify(x => x.PrintMessage(It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}