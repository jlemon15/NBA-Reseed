using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Reseed.Models
{
    public class SeasonResultViewModel
    {
        public IEnumerable<SeasonalResults> Results { get; set; }
    }
}