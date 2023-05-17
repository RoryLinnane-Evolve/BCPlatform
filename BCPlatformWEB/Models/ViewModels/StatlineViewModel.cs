namespace BCPlatformWEB.Models
{
    public class StatlineViewModel
    {
        public Guid Id { get; set; }
        public string Game { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int? Pts { get; set; }
        public int? Reb { get; set; }
        public int? Ast { get; set; }
        public int? Blk { get; set; }
        public int? Stl { get; set; }
    }
}
