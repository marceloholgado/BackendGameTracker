using GameTracker.Application.Abstractions;
using GameTracker.Domain.Entities;
using GameTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIDAsync(Guid id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game is null)
                return;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(Guid id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<Game?> GetGameByTitleAsync(string title)
        {
            return await _context.Games
                .FirstOrDefaultAsync(g => g.Title == title);
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
    }
}
