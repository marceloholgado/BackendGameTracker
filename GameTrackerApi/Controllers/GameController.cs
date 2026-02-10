using GameTracker.Api.Contracts.Requests;
using GameTracker.Api.Contracts.Responses;
using GameTracker.Api.Mappers;
using GameTracker.Application.UseCases.CreateGame;
using GameTracker.Application.UseCases.GetGame;
using GameTracker.Application.UseCases.UpdateGame;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GetGameByIdUseCase _getGameByIdUseCase;
        private readonly GetGameByTitleUseCase _getGameByTitleUseCase;
        private readonly CreateGameUseCase _createGameUseCase;
        private readonly DeleteGameUseCase _deleteGameUseCase;
        private readonly UpdateGameUseCase _updateGameUseCase;

        public GameController(
            GetGameByIdUseCase getGameUseCase,
            GetGameByTitleUseCase getGameByTitleUseCase,
            CreateGameUseCase createGameUseCase,
            DeleteGameUseCase deleteGameUseCase,
            UpdateGameUseCase updateGameUseCase)
        {
            _getGameByIdUseCase = getGameUseCase;
            _getGameByTitleUseCase = getGameByTitleUseCase;
            _createGameUseCase = createGameUseCase;
            _deleteGameUseCase = deleteGameUseCase;
            _updateGameUseCase = updateGameUseCase;
        }

        [HttpGet("health")]
        public async Task<ActionResult> Get()
        {
            return Ok("Game Tracker API is running.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponse>> GetGameById(Guid id)
        {
            var gameDto = await _getGameByIdUseCase.ExecuteAsync(id);
            return Ok(GameResponseMapper.ToResponse(gameDto));
        }

        [HttpGet("search")]
        public async Task<ActionResult<GameResponse>> GetGameByTitle([FromQuery] string title)
        {
            var gameDto = await _getGameByTitleUseCase.ExecuteAsync(title);

            return Ok(GameResponseMapper.ToResponse(gameDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameRequest game)
        {
            var command = GameResquestMapper.ToCommand(game);
            await _createGameUseCase.ExecuteAsync(command);
            // Implementation for creating a game would go here
            return CreatedAtAction(nameof(GetGameById), new { id = Guid.NewGuid() }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            await _getGameByIdUseCase.ExecuteAsync(id);
            await _deleteGameUseCase.ExecuteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(Guid id, [FromBody] GameRequest game)
        {
            var gameDto = await _getGameByIdUseCase.ExecuteAsync(id);

            var command = GameResquestMapper.ToUpdateCommand(gameDto);
            await _updateGameUseCase.ExecuteAsync(command);

            return Ok();
        }
    }
}
