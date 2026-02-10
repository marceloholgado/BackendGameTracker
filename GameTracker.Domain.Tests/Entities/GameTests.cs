using GameTracker.Domain.Entities;
using GameTracker.Domain.Enums;
using GameTracker.Domain.Exceptions;
using GameTracker.Domain.ValueObjects.Game;

namespace GameTracker.Domain.Tests.Entities
{
    public class GameTests
    {
        [Fact]
        public void Should_Start_With_Status_Of_Wishlist_When_Created()
        {
            // Arrange
            var title = new GameTitle("Super Mario World");
            var platform = Platform.PC;
            // Act
            var game = CreateDefaultGame();
            // Assert
            Assert.Equal(GameStatus.Wishlist, game.Status);
        }

        [Fact]
        public void Should_Not_Allow_Update_Status_After_Finished()
        {
            // Arrange
            var game = CreateDefaultGame();
            game.UpdateStatus(GameStatus.Finished);
            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => game.UpdateStatus(GameStatus.Playing));
            Assert.Equal("Cannot change status of a finished game.", exception.Message);
            Assert.Equal(GameStatus.Finished, game.Status);
        }

        [Fact]
        public void Should_Allow_Update_Status_When_Status_Is_Not_Finished()
        {
            // Arrange
            var game = CreateDefaultGame();
            // Act
            game.UpdateStatus(GameStatus.Playing);
            // Assert
            Assert.Equal(GameStatus.Playing, game.Status);
        }

        [Fact]
        public void Should_Not_Throw_When_New_Status_Is_Finished_And_Current_Status_Is_Finished()
        {
            // Arrange
            var game = CreateDefaultGame();
            // Act
            var exception = Record.Exception(() => game.UpdateStatus(GameStatus.Finished));
            // Assert
            Assert.Null(exception);
            Assert.Equal(GameStatus.Finished, game.Status);
        }

        private static Game CreateDefaultGame()
        {
            var title = new GameTitle("Elden Ring");
            var platform = Platform.PlayStation;

            return new Game(title, platform);
        }
    }
}
