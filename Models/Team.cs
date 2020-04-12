using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Reseed.Models
{
    public class Team
    {
        public int Season { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string BrefLink { get; set; }
        public String LogoMain { get; set; }
        public String LogoBracket { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public String Conference { get; set; }
        public String Division { get; set; }
        public int DivRank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal WinPCT { get; set; }
        public int Seed { get; set; }
        public int SemiSeed { get; set; }
        public int Top16seed { get; set; }
        public int TourneySeed { get; set; }
        public IEnumerable<Game> DivisionalGames { get; set; }
        public IEnumerable<Game> PlayoffGames { get; set; }
    }


 


}