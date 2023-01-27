using BCPlatformWEB.Models.Domain;

namespace BCPlatformWEB.Models
{
    public class UpdatePostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        //ImageNames seperated by ','
        public string ImageNames { get; set; }
        public List<IFormFile> Images { get; set; }
        public Guid Creator { get; set; }
        public Guid? Game { get; set; }
        public DateTime UploadTime { get; set; }
        public List<Game> RecentGames { get; set; }
    }
}
