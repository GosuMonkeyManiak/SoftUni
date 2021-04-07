using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private RaceEntry testEntry;

        [SetUp]
        public void Setup()
        {
            testEntry = new RaceEntry();
        }

        [Test]
        public void When_CreateEntry_ShouldHaveEmptyDictionary()
        {
            var dictonary = testEntry.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "driver");

            var insideDictionary = (Dictionary<string, UnitDriver>)dictonary.GetValue(testEntry);

            Assert.That(insideDictionary is Dictionary<string, UnitDriver>);
            Assert.AreEqual(0, insideDictionary.Count);
        }

        [Test]
        public void When_CreateEntry_CountShouldBeZero()
        {
            Assert.AreEqual(0, testEntry.Counter);
        }

        [Test]
        public void When_AddNullDriverShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => testEntry.AddDriver(null),
                "Driver cannot be null.");
        }

        [Test]
        public void When_AddExistingDriver_ShouldThrowException()
        {
            UnitDriver driver = new UnitDriver("Pesho", null);

            testEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => testEntry.AddDriver(driver),
                "Driver {0} is already added.");
        }

        [Test]
        public void When_AddDriver_ShouldBeAdded()
        {
            UnitDriver driver = new UnitDriver("Pesho", null);

            testEntry.AddDriver(driver);

            var dictonary = testEntry.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "driver");

            var insideDictionary = (Dictionary<string, UnitDriver>)dictonary.GetValue(testEntry);

            Assert.That(insideDictionary.ContainsKey(driver.Name));
        }

        [Test]
        public void When_AddDriver_CountShouldIncrease()
        {
            UnitDriver driver = new UnitDriver("Pesho", null);

            testEntry.AddDriver(driver);

            Assert.AreEqual(1, testEntry.Counter);
        }

        [Test]
        public void When_AddDriver_ShouldReturnStringMessage()
        {
            UnitDriver driver = new UnitDriver("Pesho", null);

            string msg = testEntry.AddDriver(driver);

            Assert.AreEqual($"Driver {driver.Name} added in race.", msg);
        }

        [Test]
        public void When_DriversAreBelow2_andCalculateAverageHorsePower_ShouldThrowException()
        {
            UnitDriver driver = new UnitDriver("Pesho", null);

            testEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => testEntry.CalculateAverageHorsePower(),
                "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void When_CalculateAverageHorsePower_ShouldReturnCorrectAverage()
        {
            UnitDriver firstDriver = new UnitDriver("Pesho", new UnitCar("Pesho", 100, 100));
            UnitDriver secondDriver = new UnitDriver("Gosho", new UnitCar("Gosho", 100, 100));
            UnitDriver thirdDriver = new UnitDriver("Mitko", new UnitCar("Mitko", 100, 100));

            testEntry.AddDriver(firstDriver);
            testEntry.AddDriver(secondDriver);
            testEntry.AddDriver(thirdDriver);

            double result = testEntry.CalculateAverageHorsePower();

            var dictonary = testEntry.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "driver");

            var insideDictionary = (Dictionary<string, UnitDriver>)dictonary.GetValue(testEntry);

            double expected = insideDictionary
                .Values
                .Select(c => c.Car.HorsePower)
                .Average();

            Assert.AreEqual(expected, result);
        }
    }
}
