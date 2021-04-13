using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Aquariums.Tests
{
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private string name;
        private int capacity;

        [SetUp]
        public void SetUp()
        {
            name = "Pesho";
            capacity = 50;
            aquarium = new Aquarium(name, capacity);
        }

        [Test]
        public void When_CreateAquarium_ShouldHaveAEmptyListOfFishes()
        {
            var insideList = aquarium.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "fish")
                .GetValue(aquarium);

            List<Fish> fishes = (List<Fish>)insideList;

            Assert.IsNotNull(fishes);
            Assert.AreEqual(0, fishes.Count);
        }

        [Test]
        public void Wen_CreateAquarium_NameShouldBeSet()
        {
            Assert.AreEqual(name, aquarium.Name);
        }

        [Test]
        public void When_ProvideNullName_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(
                () => aquarium = new Aquarium(null, capacity),
                "Invalid aquarium name!");
        }

        [Test]
        public void When_ProvideEmptyName_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(
                () => aquarium = new Aquarium("", capacity),
                "Invalid aquarium name!");
        }

        [Test]
        public void Wen_CreateAquarium_CapacityShouldBeSet()
        {
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [Test]
        public void When_ProvideNegativeCapacity_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => aquarium = new Aquarium(name, -1),
                "Invalid aquarium capacity!");
        }

        [Test]
        public void Wen_CreateAquarium_CountShouldBeZero()
        {
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void When_AddFishAndNotEnoughCapacity_ShouldThrowException()
        {
            aquarium = new Aquarium(name, 0);

            Assert.Throws<InvalidOperationException>(
                () => aquarium.Add(new Fish(name)),
                "Aquarium is full!");
        }

        [Test]
        public void When_AddFishAnd_FishShouldBeAdded()
        {
            aquarium.Add(new Fish(name));

            var insideList = aquarium.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "fish")
                .GetValue(aquarium);

            List<Fish> fishes = (List<Fish>)insideList;

            Assert.AreEqual(1, fishes.Count);
            Assert.AreEqual(name, fishes[0].Name);
        }

        [Test]
        public void When_AddFish_CountShouldBeIncrease()
        {
            aquarium.Add(new Fish(name));

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void When_RemoveFishAndNotExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => aquarium.RemoveFish(name),
                $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void When_RemoveFish_ShouldBeRemoved()
        {
            aquarium.Add(new Fish(name));
            aquarium.RemoveFish(name);

            var insideList = aquarium.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "fish")
                .GetValue(aquarium);

            List<Fish> fishes = (List<Fish>)insideList;

            Assert.AreEqual(0, fishes.Count);
        }

        [Test]
        public void When_RemovedFish_CountShouldBeDecrease()
        {
            aquarium.Add(new Fish(name));
            aquarium.RemoveFish(name);


            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void When_SellNotExistFish_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => aquarium.SellFish(name),
                $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void When_SellFish_FishShouldBeUnavailable()
        {
            aquarium.Add(new Fish(name));
            aquarium.SellFish(name);

            var insideList = aquarium.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "fish")
                .GetValue(aquarium);

            List<Fish> fishes = (List<Fish>)insideList;

            Assert.AreEqual(false, fishes[0].Available);
        }

        [Test]
        public void When_SellFish_ShouldReturnCorrectFish()
        {
            aquarium.Add(new Fish(name));
            Fish fish = aquarium.SellFish(name);

            Assert.AreEqual(name, fish.Name);
            Assert.AreEqual(false, fish.Available);
        }

        [Test]
        public void Report()
        {
            aquarium.Add(new Fish(name));

            string result = aquarium.Report();

            //string fishNames = string.Join(", ", this.fish.Select(f => f.Name));
            // string report = $"Fish available at {this.Name}: {fishNames}";

            string ourResult = $"Fish available at {aquarium.Name}: {name}";

            Assert.AreEqual(ourResult, result);
        }
    }
}
