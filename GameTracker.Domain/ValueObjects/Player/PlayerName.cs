
using GameTracker.Domain.Exceptions;

namespace GameTracker.Domain.ValueObjects.Player
{
    public class PlayerName : ValueObject
    {
        public String Value { get; }

        public PlayerName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Player name cannot be empty.");
            }

            if (name.Length < 3 || name.Length > 20)
            {
                throw new DomainException("Player name must be between 3 and 20 characters.");
            }

            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}