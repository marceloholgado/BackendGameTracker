using GameTracker.Application.Abstractions;
using GameTracker.Application.Commands;
using GameTracker.Domain.Entities;
using GameTracker.Domain.ValueObjects.Game;

namespace GameTracker.Application.UseCases.CreateGame
{
    public class CreateGameUseCase
    {
        public readonly IGameRepository _gameRepository;

        public CreateGameUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task ExecuteAsync(CreateGameCommand command)
        {
            var title = new GameTitle(command.Title);
            var platform = Platform.From(command.Platform);

            var game = new Game(title, platform);

            await _gameRepository.AddAsync(game);
        }
    }
}
