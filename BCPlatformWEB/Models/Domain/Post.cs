using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BCPlatformWEB.Models.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        //ImageNames seperated by ','
        public string ImageNames { get; set; }
        public Guid Creator { get; set; }
        public Guid? Game { get; set; }
        public DateTime UploadTime { get; set; }
        public Post(Guid id, string title, string description, string content, string imageNames, Guid creator, Guid? game, DateTime uploadTime)
        {
            Id = id;
            Title = title;
            Description = description;
            Content = content;
            ImageNames = imageNames;
            Creator = creator;
            Game = game;
            UploadTime = uploadTime;
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Post()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
