namespace GameTracker.Application.Commands
{
    public class UpdateGameCommand
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Platform { get; set; }
        public required string Status { get; set; }
        public int Rating { get; set; }
        public int PlaytimeHours { get; set; }
    }
}