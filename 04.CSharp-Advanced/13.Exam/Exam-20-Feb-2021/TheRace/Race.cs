using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {

        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => data.Count; }

        public void Add(Racer racer)
        {
            if (data.Count == Capacity)
            {
                return;
            }

            data.Add(racer);
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(x => x.Name == name);

            if (racer != null)
            {
                data.Remove(racer);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer racer = data
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();

            return racer;
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
