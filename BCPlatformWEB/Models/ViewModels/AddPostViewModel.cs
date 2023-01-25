using BCPlatformWEB.Models.Domain;

namespace BCPlatformWEB.Models
{
    public class AddPostViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public List<IFormFile> Images { get; set; }
        public Guid? Game { get; set; }
        public List<Game> RecentGames { get; set; }
    }
}
