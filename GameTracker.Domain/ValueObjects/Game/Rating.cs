using GameTracker.Domain.Exceptions;

namespace GameTracker.Domain.ValueObjects.Game
{
    public sealed class Rating : ValueObject
    {
        public int Stars { get; }
        public Rating(int stars)
        {
            if (stars < 1 || stars > 5)
                throw new DomainException("Rating must be between 1 and 5 stars");

            Stars = stars;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield break;
        }
    }
}
