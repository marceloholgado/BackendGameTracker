using GameTracker.Domain.Entities;

namespace GameTracker.Application.Abstractions {

    public interface IGameRepository
    {
        Task AddAsync(Game game);
        Task<Game?> GetByIdAsync(Guid id);
        Task DeleteByIDAsync(Guid id);
        Task<IReadOnlyList<Game>> GetAllAsync();
        Task<Game?> GetGameByTitleAsync(string title);
        Task UpdateAsync(Game updatedGame);
    }
}