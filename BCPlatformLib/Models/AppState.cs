using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPlatformLib.Models
{
    public class AppState
    {
        public Guid UserId { get; set; }
        public AppState(string _UserId)
        {
            UserId = Guid.Parse(_UserId);
        }
    }
}
