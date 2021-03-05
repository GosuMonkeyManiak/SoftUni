using System;
using System.Collections.Generic;
using System.Linq;

namespace FootBallTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private int rating;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Rating
        {
            get
            {
                CalculateRating();
                return rating;
            }
            private set => rating = value;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(player);
        }

        private void CalculateRating()
        {
            double sum = 0;

            foreach (var player in players)
            {
                sum += SkillLevelForEach(player);
            }

            Rating = Convert.ToInt32(sum);
        }

        private double SkillLevelForEach(Player player)
        {
            return (player.Endurance + player.Dribble + player.Passing + player.Shooting + player.Sprint) / 5.0;
        }
    }
}