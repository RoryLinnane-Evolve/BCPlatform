namespace BCPlatformWEB.Models
{
    public class AddClubViewModel
    {
        public string Name { get; set; }
        public string? Location { get; set; }
        public AddClubViewModel(string name, string? location)
        {
            Name = name;
            Location = location;
        }
    }
}
