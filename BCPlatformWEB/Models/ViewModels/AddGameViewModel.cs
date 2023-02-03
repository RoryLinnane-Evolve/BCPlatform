using BCPlatformLib.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BCPlatformWEB.Models
{
    public class AddGameViewModel
    {
        public Guid HomeTeam { get; set; }
        public Guid AwayTeam { get; set; }
        public string? Location { get; set; }
        public DateTime _DateTime { get; set; }
        public string? Info { get; set; }
        public IFormFile Scoresheet { get; set; }
        public List<Club> Teams { get; set; }
    }
}
