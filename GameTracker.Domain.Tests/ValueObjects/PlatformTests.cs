using GameTracker.Domain.ValueObjects.Game;

namespace GameTracker.Domain.Tests.ValueObjects
{
    public class PlatformTests
    {
        [Fact]
        public void Should_Create_Platform_With_Correct_Name()
        {
            // Arrange
            var platformName = "PC";
            // Act
            Platform platform = Platform.PC;
            // Assert
            Assert.Equal(platformName, platform.Name);
        }   
    }
}
