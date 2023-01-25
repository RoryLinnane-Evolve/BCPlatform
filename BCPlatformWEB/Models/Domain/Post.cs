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
    }
}
