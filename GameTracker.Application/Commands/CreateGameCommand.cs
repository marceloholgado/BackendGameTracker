namespace GameTracker.Application.Commands
{
    public class CreateGameCommand
    {
        public required string Title { get; set; }
        public required string Platform { get; set; }
        public int PlaytimeHours { get; set; }
    }
}
