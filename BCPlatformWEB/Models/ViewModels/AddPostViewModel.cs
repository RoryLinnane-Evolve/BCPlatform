using BCPlatformWEB.Models.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AddPostViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public AddPostViewModel(string title, string description, string content, List<IFormFile> images, Guid? game, List<Game> recentGames)
        {
            Title = title;
            Description = description;
            Content = content;
            Images = images;
            Game = game;
            RecentGames = recentGames;
        }
    }
}
