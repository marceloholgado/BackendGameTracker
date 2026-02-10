using GameTracker.Domain.Enums;
using GameTracker.Domain.Exceptions;
using GameTracker.Domain.ValueObjects.Game;

namespace GameTracker.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; }
        public GameTitle Title { get; private set; }
        public GameStatus Status { get; private set; }
        public Platform Platform { get; private set; }
        public Rating Rating { get; private set; }
        public int playtimeHours { get; private set; }

        public Game(GameTitle title, Platform platform)
        {
            Id = Guid.NewGuid();
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Status = GameStatus.Wishlist;
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            Rating = new Rating(1);
            playtimeHours = 0;
        }

        public void Update(
            GameTitle title,
            GameStatus status,
            Rating rating,
            int playtimeHours
        )
        {
            Title = title;
            Status = status;
            Rating = rating;
            this.playtimeHours = playtimeHours;
        }

        public void SetRating(Rating rating)
        {
            if (Status != GameStatus.Finished)
                throw new DomainException("Cannot rate a game that is not finished.");

            Rating = rating;
        }

        public void UpdateStatus(GameStatus newStatus)
        {
            if (Status == GameStatus.Finished && newStatus != GameStatus.Finished)
                throw new DomainException("Cannot change status of a finished game.");
            Status = newStatus;
        }

        public void AddPlaytime(int hours)
        {
            if (hours < 0)
                throw new DomainException("Playtime hours cannot be negative.");
            playtimeHours += hours;
        }

        public void RemovePlaytime(int hours)
        {
            if (hours < 0)
                throw new DomainException("Playtime hours to remove cannot be negative.");
            if (hours > playtimeHours)
                throw new DomainException("Cannot remove more playtime hours than recorded.");
            playtimeHours -= hours;
        }
    }
}
