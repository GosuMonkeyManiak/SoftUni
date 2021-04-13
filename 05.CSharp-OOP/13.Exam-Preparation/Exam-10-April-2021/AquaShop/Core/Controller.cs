using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorations.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration currentDecoration = decorations.FindByType(decorationType);

            currentAquarium.AddDecoration(currentDecoration);

            decorations.Remove(currentDecoration);


            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fish.GetType().Name == nameof(FreshwaterFish) && currentAquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                currentAquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (fish.GetType().Name == nameof(SaltwaterFish) && currentAquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                currentAquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return OutputMessages.UnsuitableWater;
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            currentAquarium.Feed();

            return string.Format(OutputMessages.FishFed, currentAquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            var totalSum = currentAquarium.Fish.Sum(f => f.Price) + currentAquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalSum);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}