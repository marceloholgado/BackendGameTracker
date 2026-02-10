using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace GameTracker.Api.Tests.Controller
{
    public class GameControllerIntegrationTests : IClassFixture<GameApiFactory>
    {
        private readonly HttpClient _client;

        public GameControllerIntegrationTests(GameApiFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_When_Api_Is_Running_Returns200()
        {
            // Arrange & Act
            var response = await _client.GetAsync("/game/health");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
