using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fishes;

        public void AddFish(IFish fish)
        {
            if (fishes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            fishes.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
        //"{aquariumName} ({aquariumType}):
            // Fish: {fishName1}, {fishName2}, {fishName3} (…) / none
            // Decorations: {decorationsCount}
            // Comfort: {aquariumComfort}"
            // 

            List<string> fishNames = fishes.Select(f => f.Name).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({this.GetType().Name}):");

            if (fishes.Count > 0)
            {
                sb.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            }
            else
            {
                sb.AppendLine($"Fish: none");
            }

            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}