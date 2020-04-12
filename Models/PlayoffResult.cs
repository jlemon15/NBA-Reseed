using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA_Reseed.Models
{
    public class PlayoffResult
    {
        public int Season { get; set; }

        // **********   Eastern Conference  **********


        // teams
        public Team EC_M1_Team1 { get; set; }
        public Team EC_M1_Team2 { get; set; }
        public Team EC_M2_Team1 { get; set; }
        public Team EC_M2_Team2 { get; set; }
        public Team EC_M3_Team1 { get; set; }
        public Team EC_M3_Team2 { get; set; }
        public Team EC_M4_Team1 { get; set; }
        public Team EC_M4_Team2 { get; set; }
        public Team EC_Semi1_Team1 { get; set; }
        public Team EC_Semi1_Team2 { get; set; }
        public Team EC_Semi2_Team1 { get; set; }
        public Team EC_Semi2_Team2 { get; set; }
        public Team EC_Final_Team1 { get; set; }
        public Team EC_Final_Team2 { get; set; }

            // wins
        public int EC_M1_Team1_wins { get; set; }
        public int EC_M1_Team2_wins { get; set; }
        public int EC_M2_Team1_wins { get; set; }
        public int EC_M2_Team2_wins { get; set; }
        public int EC_M3_Team1_wins { get; set; }
        public int EC_M3_Team2_wins { get; set; }
        public int EC_M4_Team1_wins { get; set; }
        public int EC_M4_Team2_wins { get; set; }
        public int EC_Semi1_Team1_wins { get; set; }
        public int EC_Semi1_Team2_wins { get; set; }
        public int EC_Semi2_Team1_wins { get; set; }
        public int EC_Semi2_Team2_wins { get; set; }
        public int EC_Final_Team1_wins { get; set; }
        public int EC_Final_Team2_wins { get; set; }

        //Western Conference  **********

            // teams
        public Team WC_M1_Team1 { get; set; }
        public Team WC_M1_Team2 { get; set; }
        public Team WC_M2_Team1 { get; set; }
        public Team WC_M2_Team2 { get; set; }
        public Team WC_M3_Team1 { get; set; }
        public Team WC_M3_Team2 { get; set; }
        public Team WC_M4_Team1 { get; set; }
        public Team WC_M4_Team2 { get; set; }
        public Team WC_Semi1_Team1 { get; set; }
        public Team WC_Semi1_Team2 { get; set; }
        public Team WC_Semi2_Team1 { get; set; }
        public Team WC_Semi2_Team2 { get; set; }
        public Team WC_Final_Team1 { get; set; }
        public Team WC_Final_Team2 { get; set; }


            // wins
        public int WC_M1_Team1_wins { get; set; }
        public int WC_M1_Team2_wins { get; set; }
        public int WC_M2_Team1_wins { get; set; }
        public int WC_M2_Team2_wins { get; set; }
        public int WC_M3_Team1_wins { get; set; }
        public int WC_M3_Team2_wins { get; set; }
        public int WC_M4_Team1_wins { get; set; }
        public int WC_M4_Team2_wins { get; set; }
        public int WC_Semi1_Team1_wins { get; set; }
        public int WC_Semi1_Team2_wins { get; set; }
        public int WC_Semi2_Team1_wins { get; set; }
        public int WC_Semi2_Team2_wins { get; set; }
        public int WC_Final_Team1_wins { get; set; }
        public int WC_Final_Team2_wins { get; set; }


        //  NBA Finals
        public Team NBA_Final_Team1 { get; set; }
        public Team NBA_Final_Team2 { get; set; }
        public int NBA_Final_Team1_wins { get; set; }
        public int NBA_Final_Team2_wins { get; set; }





    }
}