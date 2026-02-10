using GameTracker.Domain.Enums;
using GameTracker.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTracker.Application.Mappers
{
    public static class GameStatusMapper
    {
        public static GameStatus ToDomain(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new DomainException("Game status cannot be empty.");

            return status.Trim().ToLower() switch
            {
                "wishlist" => GameStatus.Wishlist,
                "playing" => GameStatus.Playing,
                "finished" => GameStatus.Finished,
                "dropped" => GameStatus.Dropped,
                _ => throw new DomainException($"Invalid game status: {status}")
            };
        }
    }
}
