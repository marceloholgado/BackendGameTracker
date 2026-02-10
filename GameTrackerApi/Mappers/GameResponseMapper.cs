using GameTracker.Api.Contracts.Responses;
using GameTracker.Application.DTOs;

namespace GameTracker.Api.Mappers
{
    public class GameResponseMapper
    {
        public static GameResponse ToResponse(GameDto dto)
        {
            return new GameResponse
            {
                Title = dto.Title,
                Status = dto.Status,
                Platform = dto.Platform
            };
        }
    }
}
