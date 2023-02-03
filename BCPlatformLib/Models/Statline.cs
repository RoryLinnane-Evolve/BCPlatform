namespace BCPlatformLib.Models
{
    public class Statline
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int Number { get; set; }
        public int? Pts { get; set; }
        public int? Reb { get; set; }
        public int? Ast { get; set; }
        public int? Blk { get; set; }
        public int? Stl { get; set; }
    }
}
