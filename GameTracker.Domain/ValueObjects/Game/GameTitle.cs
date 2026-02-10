using GameTracker.Domain.Exceptions;

namespace GameTracker.Domain.ValueObjects.Game
{
    public sealed class GameTitle : ValueObject
    {
        public string Value { get; }

        public GameTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Game title is required.");

            if (value.Length < 2)
                throw new DomainException("Game title is too short.");

            Value = value;
        }

        public static implicit operator GameTitle(string value)
        {
            return new GameTitle(value);
        }

        public static implicit operator string(GameTitle title)
        {
            return title.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
