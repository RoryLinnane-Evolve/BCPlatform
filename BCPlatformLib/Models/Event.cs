using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPlatformLib.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
        public EventType EventType { get; set; }
    }
    public enum EventType
    {
        Score1,
        Score2,
        Score3,
        Rebound,
        Steal,
        Block,
        PFoul,
        TFoul,
        UFoul
    }
}
