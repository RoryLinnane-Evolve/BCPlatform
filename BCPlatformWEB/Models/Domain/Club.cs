using Mono.TextTemplating;

namespace BCPlatformWEB.Models.Domain
{
    public class Club
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
    }
}
