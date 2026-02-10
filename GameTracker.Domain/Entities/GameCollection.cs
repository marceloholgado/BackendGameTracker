using GameTracker.Domain.Exceptions;
using GameTracker.Domain.ValueObjects.Game;

namespace GameTracker.Domain.Entities
{
    public class GameCollection
    {
        private readonly List<Game> _games = new();

        public IReadOnlyCollection<Game> Games => _games;

        public void Add(Game game)
        {
            if (_games.Contains(game))
                throw new DomainException("Game already exists in collection.");

            _games.Add(game);
        }

        public bool Contains(GameTitle title)
        {
            return _games.Any(g => g.Title.Equals(title));
        }

        public void Remove(GameTitle title)
        {
            var game = _games.FirstOrDefault(g => g.Title.Equals(title));

            if (game is null)
                throw new DomainException("Game not found.");

            _games.Remove(game);
        }
    }
}