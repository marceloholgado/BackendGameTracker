namespace GameTracker.Api.Contracts.Requests
{
    public class GameRequest
    {
        public required string Title { get; set; }
        public required string Platform { get; set; }
        public int PlaytimeHours { get; set; }
        public required string CoverUrl { get; set; }

    }
}