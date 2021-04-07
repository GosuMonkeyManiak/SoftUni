using System;
using NUnit.Framework;

namespace Computers.Tests
{
    [TestFixture]
    public class ComputerManagerTests
    {
        private Computer defaultComputer;
        private readonly string defaultManufacturer = "Asus";
        private readonly string defaultModel = "X55";
        private readonly decimal defaultPrice = 1500;

        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            this.defaultComputer = new Computer(defaultManufacturer, defaultModel, defaultPrice);
            this.computerManager = new ComputerManager();
        }

        //Computer Tests
        [Test]
        public void CheckIfComputerConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.defaultPrice, this.defaultComputer.Price);
            Assert.AreEqual(this.defaultManufacturer, this.defaultComputer.Manufacturer);
            Assert.AreEqual(this.defaultModel, this.defaultComputer.Model);
        }

        //ComputerManager Tests

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.That(this.computerManager.Count, Is.EqualTo(0));
            Assert.That(this.computerManager.Computers, Is.Empty);
        }
        [Test]
        public void CheckIfCountWorksCorrectly()
        {
            this.computerManager.AddComputer(this.defaultComputer);
            Assert.That(this.computerManager.Count, Is.EqualTo(1));
            Assert.That(this.computerManager.Computers, Has.Member(this.defaultComputer));
        }

        [Test]
        public void AddShouldThrowExceptionWithExistingComputer()
        {
            this.computerManager.AddComputer(this.defaultComputer);
            Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.AddComputer(this.defaultComputer);
            }, "This computer already exists.");
        }

        [Test]
        public void AddShouldIncreaseCountWhenSuccessful()
        {
            this.computerManager.AddComputer(this.defaultComputer);

            Assert.That(this.computerManager.Count, Is.EqualTo(1));
            Assert.That(this.computerManager.Computers, Has.Member(this.defaultComputer));
        }

        [Test]
        public void AddShouldThrowExceptionWithNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.AddComputer(null);
            }, "Can not be null.");
        }

        [Test]
        public void RemoveComputerShouldRemoveCorrectComputer()
        {
            this.computerManager.AddComputer(this.defaultComputer);
            var result = this.computerManager.RemoveComputer(this.defaultManufacturer, this.defaultModel);

            Assert.AreSame(this.defaultComputer, result);
            Assert.That(this.computerManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveShouldThrowExceptionWithInvalidComputer()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.RemoveComputer(this.defaultManufacturer, "Acer");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldWorkCorrectly()
        {
            this.computerManager.AddComputer(this.defaultComputer);
            var result = this.computerManager.GetComputer(this.defaultManufacturer, this.defaultModel);

            Assert.AreSame(this.defaultComputer, result);
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithInvalidData()
        {
            this.computerManager.AddComputer(this.defaultComputer);
            Assert.Throws<ArgumentException>(() =>
            {
                this.computerManager.GetComputer(
                    "HP", "XC300");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => { this.computerManager.GetComputer(null, this.defaultModel); });
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithNullModel()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.GetComputer(this.defaultManufacturer, null);
            });
        }

        [Test]
        public void GetByManufacturerShouldThrowExceptionWithNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.GetComputersByManufacturer(null);
            });
        }

        [Test]
        public void GetAllByManufacturerShouldReturnCorrectCollection()
        {
            this.computerManager.AddComputer(this.defaultComputer);
            this.computerManager.AddComputer(new Computer(this.defaultManufacturer, "K210", 899.99m));
            this.computerManager.AddComputer(new Computer("Pesho", "P34", 420));
            var collection = this.computerManager.GetComputersByManufacturer(this.defaultManufacturer);

            Assert.That(collection.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAllByManufacturerShouldReturnZeroWithNoMatches()
        {
            var collection = this.computerManager.GetComputersByManufacturer("Mac");

            Assert.That(collection.Count, Is.EqualTo(0));
        }
    }
}
