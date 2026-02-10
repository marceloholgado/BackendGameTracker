using GameTracker.Domain.Exceptions;
using GameTracker.Domain.ValueObjects.Player;

namespace GameTracker.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; private set; }
        public PlayerName PlayerName { get; private set; } // Alterado para permitir atribuição interna
        public Password Password { get; private set; }
        public Email Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public GameCollection GameCollection { get; private set; }

        public Player(Guid id, PlayerName playerName, Password password, Email email, DateTime createdAt, GameCollection gameCollection)
        {
            Id = id;
            PlayerName = playerName;
            Password = password;
            Email = email;
            CreatedAt = createdAt;
            GameCollection = gameCollection;
        }

        public void RenamePlayerName(string newPlayerName)
        {
            // Logic to rename the player's username
            if (string.IsNullOrWhiteSpace(newPlayerName))
            {
                throw new DomainException("Player name cannot be empty.");
            }
            
            char firstLetter = newPlayerName[0];
            if (firstLetter < 0x41 || firstLetter > 0x5A)
            {
                throw new DomainException("Player name must start with an uppercase letter (A-Z).");
            }

            if (newPlayerName.Length < 3 || newPlayerName.Length > 20)
            {
                throw new DomainException("Player name must be between 3 and 20 characters.");
            }

            if (newPlayerName == PlayerName.Value)
            {
                throw new DomainException("New player name must be different from the current name.");
            }

            PlayerName = new PlayerName(newPlayerName);
        }

    }
}
