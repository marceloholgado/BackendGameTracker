using GameTracker.Application.Abstractions;
using GameTracker.Application.DTOs;
using GameTracker.Domain.Entities;
using GameTracker.Domain.Exceptions;

namespace GameTracker.Application.UseCases.GetGame
{
    public class GetGameByIdUseCase
    {
        private readonly IGameRepository _gameRepository;

        public GetGameByIdUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameDto> ExecuteAsync(Guid gameId)
        {
            Game? game = await _gameRepository.GetByIdAsync(gameId);
            if (game == null)
            {
                throw new GameNotFoundException($"Game with ID {gameId} not found.");
            }
            return new GameDto
            {
                Id = game.Id,
                Title = game.Title,
                Status = game.Status.ToString(),
                Platform = game.Platform.Name,
                Rating = game.Rating.Stars,
                PlaytimeHours = game.playtimeHours
            };
        }
    }
}
