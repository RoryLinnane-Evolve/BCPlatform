using BCPlatformLib.Models;

namespace BCPlatformWEB.Models
{
    public class UpdateGameViewModel
    {
        public Guid Id { get; set; }
        public Guid HomeTeam { get; set; }
        public Guid AwayTeam { get; set; }
        public string? Location { get; set; }
        public DateTime _DateTime { get; set; }
        public string? Info { get; set; }
        public string ScoresheetName { get; set; }
        public List<Club> Teams { get; set; }
    }
}
