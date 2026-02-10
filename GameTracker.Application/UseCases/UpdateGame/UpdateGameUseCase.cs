using GameTracker.Application.Abstractions;
using GameTracker.Application.Commands;
using GameTracker.Application.Mappers;
using GameTracker.Domain.Exceptions;
using GameTracker.Domain.ValueObjects.Game;


namespace GameTracker.Application.UseCases.UpdateGame
{
    public class UpdateGameUseCase
    {
        private readonly IGameRepository _gameRepository;

        public UpdateGameUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task ExecuteAsync(UpdateGameCommand command)
        {
            var game = await _gameRepository.GetByIdAsync(command.Id)
                ?? throw new GameNotFoundException($"Game {command.Id} not found");

            game.Update(
                new GameTitle(command.Title),
                GameStatusMapper.ToDomain(command.Status),
                new Rating(command.Rating),
                command.PlaytimeHours
            );

            await _gameRepository.UpdateAsync(game);
        }
    }
}
