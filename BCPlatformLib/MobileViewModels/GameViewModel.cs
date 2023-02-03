using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPlatformLib.MobileViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string? Location { get; set; }
        public DateTime _DateTime { get; set; }
        public string? Info { get; set; }
        public string ScoresheetName { get; set; }
    }
}
