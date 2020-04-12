using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Reseed.Models
{
    public class SeasonalResults
    {
        public int Season { get; set; }
        public string CelebrationImage { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<PlayoffResult> SeasonalPlayoffs {get; set;}
    }
}