using CodeFirst.Models.NBA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Data
{
    public class DummyData
    {
        public static System.Collections.Generic.List<Team> getTeams()
        {
            List<Team> teams = new List<Team>()
            {
                new Team()
                {
                    TeamName="Warriors",
                    City="GoldenState",
                    State="California",

                },
                new Team()
                {
                    TeamName="Lakers",
                    City="LosAngeles",
                    State="California",

                },
                new Team()
                {
                    TeamName="Cavaliers",
                    City="Cleveland",
                    State="Ohio",
                }
            };
            return teams;
        }
        public static List<Player> getPlayers(NbaContext context)
        {
            List<Player> players = new List<Player>()
            {
                new Player
                {

                    FirstName = "Stephen",
                    LastName = "Curry",
                    TeamName = context.Teams.Find("Warriors").TeamName,
                    Position = "Guard"
                },
                new Player
                {

                    FirstName = "Lebron",
                    LastName = "James",
                    TeamName = context.Teams.Find("Lakers").TeamName,
                    Position = "Forward"
                },
                new Player
                {

                    FirstName = "Tristan",
                    LastName = "Thompson",
                    TeamName = context.Teams.Find("Cavaliers").TeamName,
                    Position = "Center"
                },
            };
            return players;
        }
    }
}