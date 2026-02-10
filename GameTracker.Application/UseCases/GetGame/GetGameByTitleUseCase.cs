using GameTracker.Application.Abstractions;
using GameTracker.Application.DTOs;
using GameTracker.Domain.Exceptions;
using GameTracker.Domain.ValueObjects.Game;

namespace GameTracker.Application.UseCases.GetGame
{
    public class GetGameByTitleUseCase
    {
        private readonly IGameRepository _gameRepository;

        public GetGameByTitleUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameDto> ExecuteAsync(GameTitle title)
        {
            var game = await _gameRepository.GetGameByTitleAsync(title);

            if (game == null) throw new GameNotFoundException($"Game with Title {title} not fouund.");

            return new GameDto
            {
                Id = game.Id,
                Title = game.Title.Value,
                Platform = game.Platform?.ToString() ?? string.Empty,
                Status = game.Status.ToString(),
                Rating = game.Rating.Stars,
                PlaytimeHours = game.playtimeHours
            };
        }
    }
}
