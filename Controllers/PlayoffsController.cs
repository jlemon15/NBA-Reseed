using NBA_Reseed.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBA_Reseed.Controllers
{
    public class PlayoffsController : Controller
    {
        // GET: Playoffs
        public ActionResult Index()
        {

            string connStr = "Data Source=SQL5047.site4now.net,1433;Initial Catalog=DB_A4FBF7_nbareseed;User Id=DB_A4FBF7_nbareseed_admin;Password=5y2eB4LJk3;";
            SqlConnection cnn = new SqlConnection(connStr);
            cnn.Open();
            SqlCommand cmdPlayoffResults = new SqlCommand("ws_PlayoffResults", cnn);
            cmdPlayoffResults.CommandType = CommandType.StoredProcedure;
            SqlDataReader readerRWplayoffResults = cmdPlayoffResults.ExecuteReader();

            PlayoffViewModel playoffYears = new PlayoffViewModel();
            List<bracket_RW> playoffYears_ = new List<bracket_RW>();
            int counter = 0;
            int rowCount = 0;
            bracket_RW bracket = new bracket_RW();


            while (readerRWplayoffResults.Read())
            {

                if (counter < 15)
                {

                    if (counter == 0)
                    {
                        bracket = new bracket_RW();
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.westM1_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.westM1_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.westM1_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.westM1_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.westM1_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.westM1_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 1)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.westM2_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.westM2_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.westM2_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.westM2_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.westM2_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.westM2_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 2)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.westM3_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.westM3_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.westM3_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.westM3_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.westM3_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.westM3_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 3)
                    {
                        bracket.westM4_team1 = Convert.ToString(readerRWplayoffResults[0]);
                        bracket.westM4_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.westM4_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.westM4_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.westM4_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.westM4_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 4)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.westM5_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.westM5_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.westM5_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.westM5_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.westM5_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.westM5_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 5)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.westM6_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.westM6_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.westM6_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.westM6_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.westM6_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.westM6_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 6)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.westM7_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.westM7_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.westM7_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.westM7_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.westM7_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.westM7_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 7)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.eastM1_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.eastM1_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.eastM1_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.eastM1_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.eastM1_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.eastM1_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 8)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.eastM2_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.eastM2_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.eastM2_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.eastM2_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.eastM2_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.eastM2_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 9)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.eastM3_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.eastM3_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.eastM3_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.eastM3_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.eastM3_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.eastM3_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 10)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.eastM4_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.eastM4_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.eastM4_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.eastM4_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.eastM4_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.eastM4_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }


                    else if (counter == 11)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.eastM5_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.eastM5_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.eastM5_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.eastM5_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.eastM5_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.eastM5_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 12)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.eastM6_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.eastM6_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.eastM6_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.eastM6_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.eastM6_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.eastM6_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else if (counter == 13)
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.eastM7_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.eastM7_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.eastM7_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.eastM7_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.eastM7_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.eastM7_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        counter++;
                    }

                    else
                    {
                        bracket.Year = Convert.ToInt32(readerRWplayoffResults[0]);
                        bracket.finals_team1 = Convert.ToString(readerRWplayoffResults[2]);
                        bracket.finals_team1_logo = Convert.ToString(readerRWplayoffResults[4]);
                        bracket.finals_team1_wins = Convert.ToInt32(readerRWplayoffResults[3]);
                        bracket.finals_team2 = Convert.ToString(readerRWplayoffResults[5]);
                        bracket.finals_team2_logo = Convert.ToString(readerRWplayoffResults[7]);
                        bracket.finals_team2_wins = Convert.ToInt32(readerRWplayoffResults[6]);
                        playoffYears_.Add(bracket);
                        counter = 0;

                    }
                }


                playoffYears.PlayoffsYear = playoffYears_;
                rowCount++;
            }
            cnn.Close();

            return View(playoffYears);

        }
    }
}