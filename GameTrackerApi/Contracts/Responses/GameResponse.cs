namespace GameTracker.Api.Contracts.Responses
{
    public class GameResponse
    {
        public required string Title { get; set; }
        public required string Status { get; set; }
        public required string Platform { get; set; }
    }
}
