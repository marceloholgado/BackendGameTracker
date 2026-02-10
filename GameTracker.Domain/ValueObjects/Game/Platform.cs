using GameTracker.Domain.Exceptions;

namespace GameTracker.Domain.ValueObjects.Game;

public sealed class Platform : ValueObject
{
    public string Name { get; set; }

    private Platform(string name)
    {
        Name = name;
    }

    public static Platform PC => new Platform("PC");
    public static Platform PlayStation => new Platform("PlayStation");
    public static Platform Xbox => new Platform("Xbox");
    public static Platform Nintendo => new Platform("Nintendo");
    public static Platform Mobile => new Platform("Mobile");

    public static Platform From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Platform cannot be empty.");

        return value.Trim().ToLowerInvariant() switch
        {
            "pc" => PC,
            "playstation" or "ps" or "ps5" or "ps4" => PlayStation,
            "xbox" => Xbox,
            "nintendo" => Nintendo,
            "mobile" => Mobile,
            _ => throw new DomainException($"Invalid platform '{value}'.")
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
