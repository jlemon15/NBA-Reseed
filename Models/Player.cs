using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Reseed.Models
{
    public class Player
    {
        public int Season { get; set;} 
        public String Name { get; set; }
        public String Team { get; set; }
        public String Position { get; set; }
        public Decimal PPG { get; set; }
        public Decimal RPG { get; set; }
        public Decimal APG { get; set; }
        public Decimal BPG { get; set; }
        public IEnumerable<string> Awards { get; set; }
    }
}