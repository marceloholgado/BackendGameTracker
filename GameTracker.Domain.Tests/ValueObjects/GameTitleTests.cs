using GameTracker.Domain.Exceptions;
using GameTracker.Domain.ValueObjects.Game;

namespace GameTracker.Domain.Tests.ValueObjects
{
    public class GameTitleTests
    {

        [Fact]
        public void Should_Throw_Exception_Creating_GameTitle_When_Value_Is_Null()
        {
            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new GameTitle(null!));
            Assert.Equal("Game title is required.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_Creating_GameTitle_When_Value_Is_Empty()
        {
            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new GameTitle(string.Empty));
            Assert.Equal("Game title is required.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_Creating_GameTitle_When_Value_Is_Whitespace()
        {
            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new GameTitle("   "));
            Assert.Equal("Game title is required.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_Creating_GameTitle_When_Value_Is_Too_Short()
        {
            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new GameTitle("A"));
            Assert.Equal("Game title is too short.", exception.Message);
        }

        [Fact]
        public void Should_Create_GameTitle_When_Value_Is_Valid()
        {
            // Arrange
            var validTitle = "The Legend of Zelda";
            // Act
            var gameTitle = new GameTitle(validTitle);
            // Assert
            Assert.Equal(validTitle, gameTitle.Value);
        }

        [Fact]
        public void Should_Allow_Implicit_Conversion_Between_String_And_GameTitle()
        {
            // Arrange
            var titleString = "Super Mario Odyssey";
            // Act
            GameTitle gameTitle = titleString; // Implicit conversion from string to GameTitle
            string convertedBack = gameTitle; // Implicit conversion from GameTitle to string
            // Assert
            Assert.Equal(titleString, gameTitle.Value);
            Assert.Equal(titleString, convertedBack);
        }
    }
}
