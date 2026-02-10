using GameTracker.Application.Abstractions;

namespace GameTracker.Api.Controllers
{
    public sealed class DeleteGameUseCase
    {
        private readonly IGameRepository _gameRepository;

        public DeleteGameUseCase(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task ExecuteAsync(Guid gameId)
        {
            await _gameRepository.DeleteByIDAsync(gameId);
        }
    }
}