using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Reseed.Models
{
    public class PlayoffMap
    {
        public int Season { get; set; }
        public int MatchupID { get; set; }
        public string Team1 { get; set; }
        public int Team1wins { get; set; }
        public string Team2 { get; set; }
        public int Team2wins { get; set; }
        public string Winner { get; set; }
    }
}