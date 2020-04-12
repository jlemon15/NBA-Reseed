using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBA_Reseed.Models;


namespace NBA_Reseed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            string connStr = "Data Source=SQL5047.site4now.net,1433;Initial Catalog=DB_A4FBF7_nbareseed;User Id=DB_A4FBF7_nbareseed_admin;Password=5y2eB4LJk3;";
            SqlConnection cnn = new SqlConnection(connStr);
            cnn.Open();
            SqlCommand cmdYearlyResults = new SqlCommand("ws_YearlyResults", cnn);
            cmdYearlyResults.CommandType = CommandType.StoredProcedure;

            // Team Info
            // Player info
            // Game info
            // Playoff Results
            SqlDataReader readerYearlyResults = cmdYearlyResults.ExecuteReader();
            List<SeasonalResults> seasonalResults = new List<SeasonalResults>();

            // Main List objects 
            List<Team> teams = new List<Team>();
            List<Player> players = new List<Player>();
            List<Game> divGames = new List<Game>();
            List<AwardWinner> awardWinners = new List<AwardWinner>();
            List<PlayoffMap> playoffMaps = new List<PlayoffMap>();
            List<PlayoffResult> playoffResults = new List<PlayoffResult>();
            List<int> seasons = new List<int>();
            List<CelebrationImage> celebrationImages = new List<CelebrationImage>();
            SeasonResultViewModel seasonResultsVM = new SeasonResultViewModel();


            #region Results Gathering

            // *************************    General Team Info Gather  *************************   

            while (readerYearlyResults.Read())
            {
                Team newTeam = new Team();
                newTeam.Season = Convert.ToInt32(readerYearlyResults[0]);
                newTeam.Name = Convert.ToString(readerYearlyResults[1]);
                newTeam.Abbreviation = Convert.ToString(readerYearlyResults[2]);
                newTeam.BrefLink = Convert.ToString(readerYearlyResults[3]);
                newTeam.LogoMain = Convert.ToString(readerYearlyResults[4]);
                newTeam.LogoBracket = Convert.ToString(readerYearlyResults[5]);
                newTeam.Conference = Convert.ToString(readerYearlyResults[6]);
                newTeam.Division = Convert.ToString(readerYearlyResults[7]);
                newTeam.DivRank = Convert.ToInt32(readerYearlyResults[8]);
                newTeam.Wins = Convert.ToInt32(readerYearlyResults[9]);
                newTeam.Losses = Convert.ToInt32(readerYearlyResults[10]);
                newTeam.WinPCT = Convert.ToDecimal(readerYearlyResults[11]);
                newTeam.Seed = Convert.ToInt32(readerYearlyResults[12]);
                newTeam.SemiSeed = Convert.ToInt32(readerYearlyResults[13]);
                newTeam.Top16seed = Convert.ToInt32(readerYearlyResults[14]);
                newTeam.TourneySeed = Convert.ToInt32(readerYearlyResults[15]);
                teams.Add(newTeam);
            }

            readerYearlyResults.NextResult();

            // *************************    General Player Info Gather  *************************   


            while (readerYearlyResults.Read())
            {
                Player newPlayer = new Player();
                newPlayer.Season = Convert.ToInt32(readerYearlyResults[0]);
                newPlayer.Name = Convert.ToString(readerYearlyResults[1]);
                newPlayer.Team = Convert.ToString(readerYearlyResults[2]);
                newPlayer.Position = Convert.ToString(readerYearlyResults[3]);
                newPlayer.PPG = Convert.ToDecimal(readerYearlyResults[4]);
                newPlayer.RPG = Convert.ToDecimal(readerYearlyResults[5]);
                newPlayer.APG = Convert.ToDecimal(readerYearlyResults[6]);
                newPlayer.BPG = Convert.ToDecimal(readerYearlyResults[7]);
                players.Add(newPlayer);
            }

            readerYearlyResults.NextResult();

            // *************************    Player Award Info Gather  *************************   


            while (readerYearlyResults.Read())
            {
                AwardWinner newAwardwinner = new AwardWinner();
                newAwardwinner.Season = Convert.ToInt32(readerYearlyResults[0]);
                newAwardwinner.Name = Convert.ToString(readerYearlyResults[1]);
                newAwardwinner.Award = Convert.ToString(readerYearlyResults[2]);
                awardWinners.Add(newAwardwinner);
            }


            foreach (var player in players)
            {
                player.Awards = (from award in awardWinners
                                 where award.Season == player.Season && award.Name == player.Name
                                 select award.Award).ToList();


            }

            // Assings players to teams

            foreach (var team in teams)
            {
                team.Players = (from player in players
                                where player.Season == team.Season && player.Team == team.Abbreviation
                                select player).ToList();
            }


            readerYearlyResults.NextResult();

            // *************************    Divisional Game Gather  *************************   


            while (readerYearlyResults.Read())
            {
                Game newGame = new Game();
                newGame.Season = Convert.ToInt32(readerYearlyResults[0]);
                newGame.GameDate = Convert.ToDateTime(readerYearlyResults[1]);
                newGame.AwayTeam = Convert.ToString(readerYearlyResults[2]);
                newGame.AwayScore = Convert.ToInt32(readerYearlyResults[3]);
                newGame.HomeTeam = Convert.ToString(readerYearlyResults[4]);
                newGame.HomeScore = Convert.ToInt32(readerYearlyResults[5]);
                newGame.Winner = Convert.ToString(readerYearlyResults[6]);
                newGame.division = Convert.ToString(readerYearlyResults[7]);
                divGames.Add(newGame);
            }

            // Team and Game Joining

            foreach (var team in teams)
            {
                team.DivisionalGames = (from game in divGames
                                        where game.Season == team.Season && (game.HomeTeam == team.Abbreviation || game.AwayTeam == team.Abbreviation)
                                        select game).ToList();
            }

            readerYearlyResults.NextResult();

            // *************************    Playoff Bracket Mapping  *************************   


            while (readerYearlyResults.Read())
            {
                PlayoffMap newPlayoffMap = new PlayoffMap();
                newPlayoffMap.Season = Convert.ToInt32(readerYearlyResults[0]);
                newPlayoffMap.MatchupID = Convert.ToInt32(readerYearlyResults[1]);
                newPlayoffMap.Team1 = Convert.ToString(readerYearlyResults[3]);
                newPlayoffMap.Team1wins = Convert.ToInt32(readerYearlyResults[4]);
                newPlayoffMap.Team2 = Convert.ToString(readerYearlyResults[5]);
                newPlayoffMap.Team2wins = Convert.ToInt32(readerYearlyResults[6]);
                newPlayoffMap.Winner = Convert.ToString(readerYearlyResults[7]);
                playoffMaps.Add(newPlayoffMap);
            }

            readerYearlyResults.NextResult();



            while (readerYearlyResults.Read())
            {
                int newYear;
                newYear = Convert.ToInt32(readerYearlyResults[0]);
                seasons.Add(newYear);
            }

            foreach (var season in seasons)
            {
                PlayoffResult newPlayoffResult = new PlayoffResult();
                newPlayoffResult.Season = season;

                var Results = (from playoff in playoffMaps
                               where playoff.Season == season
                               orderby playoff.MatchupID
                               select playoff);

                #region Team Object Assignmnt



                // Western Conference

                newPlayoffResult.WC_M1_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(0).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.WC_M1_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(0).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.WC_M2_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(1).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.WC_M2_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(1).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.WC_M3_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(2).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.WC_M3_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(2).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.WC_M4_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(3).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.WC_M4_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(3).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.WC_Semi1_Team1 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(4).Team1
                                                   select team).ElementAt(0);

                newPlayoffResult.WC_Semi1_Team2 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(4).Team2
                                                   select team).ElementAt(0);

                newPlayoffResult.WC_Semi2_Team1 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(5).Team1
                                                   select team).ElementAt(0);

                newPlayoffResult.WC_Semi2_Team2 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(5).Team2
                                                   select team).ElementAt(0);

                newPlayoffResult.WC_Final_Team1 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(6).Team1
                                                   select team).ElementAt(0);

                newPlayoffResult.WC_Final_Team2 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(6).Team2
                                                   select team).ElementAt(0);

                // Eastern Conference

                newPlayoffResult.EC_M1_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(7).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.EC_M1_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(7).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.EC_M2_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(8).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.EC_M2_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(8).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.EC_M3_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(9).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.EC_M3_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(9).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.EC_M4_Team1 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(10).Team1
                                                select team).ElementAt(0);

                newPlayoffResult.EC_M4_Team2 = (from team in teams
                                                where team.Season == season && team.Abbreviation == Results.ElementAt(10).Team2
                                                select team).ElementAt(0);

                newPlayoffResult.EC_Semi1_Team1 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(11).Team1
                                                   select team).ElementAt(0);

                newPlayoffResult.EC_Semi1_Team2 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(11).Team2
                                                   select team).ElementAt(0);

                newPlayoffResult.EC_Semi2_Team1 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(12).Team1
                                                   select team).ElementAt(0);

                newPlayoffResult.EC_Semi2_Team2 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(12).Team2
                                                   select team).ElementAt(0);

                newPlayoffResult.EC_Final_Team1 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(13).Team1
                                                   select team).ElementAt(0);

                newPlayoffResult.EC_Final_Team2 = (from team in teams
                                                   where team.Season == season && team.Abbreviation == Results.ElementAt(13).Team2
                                                   select team).ElementAt(0);

                // Finals

                newPlayoffResult.NBA_Final_Team1 = (from team in teams
                                                    where team.Season == season && team.Abbreviation == Results.ElementAt(14).Team1
                                                    select team).ElementAt(0);

                newPlayoffResult.NBA_Final_Team2 = (from team in teams
                                                    where team.Season == season && team.Abbreviation == Results.ElementAt(14).Team2
                                                    select team).ElementAt(0);

                #endregion

                #region Team Wins


                // Western Conference

                newPlayoffResult.WC_M1_Team1_wins = Results.ElementAt(0).Team1wins;

                newPlayoffResult.WC_M1_Team2_wins = Results.ElementAt(0).Team2wins;

                newPlayoffResult.WC_M2_Team1_wins = Results.ElementAt(1).Team1wins;

                newPlayoffResult.WC_M2_Team2_wins = Results.ElementAt(1).Team2wins;

                newPlayoffResult.WC_M3_Team1_wins = Results.ElementAt(2).Team1wins;

                newPlayoffResult.WC_M3_Team2_wins = Results.ElementAt(2).Team2wins;

                newPlayoffResult.WC_M4_Team1_wins = Results.ElementAt(3).Team1wins;

                newPlayoffResult.WC_M4_Team2_wins = Results.ElementAt(3).Team2wins;

                newPlayoffResult.WC_Semi1_Team1_wins = Results.ElementAt(4).Team1wins;

                newPlayoffResult.WC_Semi1_Team2_wins = Results.ElementAt(4).Team2wins;

                newPlayoffResult.WC_Semi2_Team1_wins = Results.ElementAt(5).Team1wins;

                newPlayoffResult.WC_Semi2_Team2_wins = Results.ElementAt(5).Team2wins;

                newPlayoffResult.WC_Final_Team1_wins = Results.ElementAt(6).Team1wins;

                newPlayoffResult.WC_Final_Team2_wins = Results.ElementAt(6).Team2wins;

                // Eastern Conference

                newPlayoffResult.EC_M1_Team1_wins = Results.ElementAt(7).Team1wins;

                newPlayoffResult.EC_M1_Team2_wins = Results.ElementAt(7).Team2wins;

                newPlayoffResult.EC_M2_Team1_wins = Results.ElementAt(8).Team1wins;

                newPlayoffResult.EC_M2_Team2_wins = Results.ElementAt(8).Team2wins;

                newPlayoffResult.EC_M3_Team1_wins = Results.ElementAt(9).Team1wins;

                newPlayoffResult.EC_M3_Team2_wins = Results.ElementAt(9).Team2wins;

                newPlayoffResult.EC_M4_Team1_wins = Results.ElementAt(10).Team1wins;

                newPlayoffResult.EC_M4_Team2_wins = Results.ElementAt(10).Team2wins;

                newPlayoffResult.EC_Semi1_Team1_wins = Results.ElementAt(11).Team1wins;

                newPlayoffResult.EC_Semi1_Team2_wins = Results.ElementAt(11).Team2wins;

                newPlayoffResult.EC_Semi2_Team1_wins = Results.ElementAt(12).Team1wins;

                newPlayoffResult.EC_Semi2_Team2_wins = Results.ElementAt(12).Team2wins;

                newPlayoffResult.EC_Final_Team1_wins = Results.ElementAt(13).Team1wins;

                newPlayoffResult.EC_Final_Team2_wins = Results.ElementAt(13).Team2wins;

                // Finals

                newPlayoffResult.NBA_Final_Team1_wins = Results.ElementAt(14).Team1wins;

                newPlayoffResult.NBA_Final_Team2_wins = Results.ElementAt(14).Team2wins;

                #endregion

                playoffResults.Add(newPlayoffResult);

            }

            readerYearlyResults.NextResult();

            // *************************    Celebration Image  *************************   


            while (readerYearlyResults.Read())
            {
                CelebrationImage newCelebrationImage = new CelebrationImage();
                newCelebrationImage.Season = Convert.ToInt32(readerYearlyResults[0]);
                newCelebrationImage.ImagePath = Convert.ToString(readerYearlyResults[1]);
                celebrationImages.Add(newCelebrationImage);
            }

            #endregion

            #region Seasonal Results Build

            foreach (var season in seasons)
            {
                SeasonalResults newSeasonalResult = new SeasonalResults();
                newSeasonalResult.Season = season;
                newSeasonalResult.CelebrationImage = (from image in celebrationImages
                                                      where image.Season == season
                                                      select image.ImagePath).ElementAt(0);

                newSeasonalResult.Teams = (from team in teams
                                           where team.Season == season
                                           select team).ToList();

                newSeasonalResult.SeasonalPlayoffs = (from playoff in playoffResults
                                                      where playoff.Season == season
                                                      select playoff).ToList();

                seasonalResults.Add(newSeasonalResult);

            }

            seasonResultsVM.Results = seasonalResults;


            #endregion

            return View(seasonResultsVM);
        }




    }
}