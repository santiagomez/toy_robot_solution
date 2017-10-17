using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Commands;

namespace ToyRobot.Tests.Commands
{
    [TestClass]
    public class UserCommandExitTests
    {
        private readonly UserCommandExit _userCommand = new UserCommandExit();

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
        public void WhenGameContextIsValidThenExecuteSetsGameTerminatedToTrue()
        {
            // Arrange
            IGameContext gameContext = new GameContext
            {
                GameTerminated = false
            };

            // Act
            var success = _userCommand.Execute(gameContext);

            // Assert
            Assert.IsTrue(success);
            Assert.IsTrue(gameContext.GameTerminated);
        }
    }
}