namespace BCPlatformWEB.Models.Domain
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid HomeTeam { get; set; }
        public Guid AwayTeam { get; set; }
        public string? Location { get; set; }
        public DateTime _DateTime { get; set; }
        public string? Info { get; set; }
        public string ScoresheetName { get; set; }
    }
}
