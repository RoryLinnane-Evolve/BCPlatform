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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UpdatePostViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public UpdatePostViewModel(Guid id, string title, string description, string content, string imageNames, List<IFormFile> images, Guid creator, Guid? game, DateTime uploadTime, List<Game> recentGames)
        {
            Id = id;
            Title = title;
            Description = description;
            Content = content;
            ImageNames = imageNames;
            Images = images;
            Creator = creator;
            Game = game;
            UploadTime = uploadTime;
            RecentGames = recentGames;
        }
    }
}
