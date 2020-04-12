using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Reseed.Models
{
    public class Game
    {
        public int Season { get; set; }
        public DateTime GameDate { get; set; }
        public string AwayTeam { get; set; }
        public int AwayScore { get; set; }
        public string HomeTeam { get; set; }
        public int HomeScore { get; set; }
        public string Winner { get; set; }

        public string division { get; set; }
    }
}