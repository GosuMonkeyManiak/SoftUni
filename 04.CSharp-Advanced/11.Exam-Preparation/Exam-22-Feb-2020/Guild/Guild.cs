using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => roster.Count; }

        public void AddPlayer(Player player)
        {
            if (roster.Count == Capacity)
            {
                return;
            }

            roster.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);

            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
                return;
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);

            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
                return;
            }
        }

        public Player[] KickPlayersByClass(string Class)
        {
            List<Player> toRemove = roster
                .Where(x => x.Class == Class)
                .ToList();

            roster.RemoveAll(x => x.Class == Class);

            return toRemove.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
