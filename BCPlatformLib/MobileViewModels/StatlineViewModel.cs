using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPlatformLib.MobileViewModels
{
    public class StatlineViewModel
    {
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
        public int Number { get; set; }
        public int? Pts { get; set; }
        public int? Reb { get; set; }
        public int? Ast { get; set; }
        public int? Blk { get; set; }
        public int? Stl { get; set; }
    }
}
