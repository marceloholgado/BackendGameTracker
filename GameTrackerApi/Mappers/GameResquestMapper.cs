using GameTracker.Api.Contracts.Requests;
using GameTracker.Application.Commands;
using GameTracker.Application.DTOs;

namespace GameTracker.Api.Mappers
{
    public class GameResquestMapper
    {
        public static CreateGameCommand ToCommand(GameRequest request)
        {
            return new CreateGameCommand
            {
                Title = request.Title,
                Platform = request.Platform,
                PlaytimeHours = request.PlaytimeHours
            };
        }

        public static UpdateGameCommand ToUpdateCommand(GameDto dto)
        {
            return new UpdateGameCommand
            {
                Id = dto.Id,
                Title = dto.Title,
                Platform = dto.Platform,
                Status = dto.Status,
                Rating = dto.Rating,
                PlaytimeHours = dto.PlaytimeHours
            };
        }
    }
}
