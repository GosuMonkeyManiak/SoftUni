using System;
using NUnit.Framework;

namespace CarManager.Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("1900", "BMW", 2.3, 600);
        }

        [Test]
        public void When_MakeNewCar_FuelAmountShouldBeZero()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void When_ProvideMakeYear_ShouldBeSet()
        {
            Assert.AreEqual("1900", car.Make);
        }

        [Test]
        public void When_ProvideModel_ShouldBeSet()
        {
            Assert.AreEqual("BMW", car.Model);
        }

        [Test]
        public void When_ProvideFuelConsumption_ShouldBeSet()
        {
            Assert.AreEqual(2.3, car.FuelConsumption);
        }

        [Test]
        public void When_ProvideFuelCapacity_ShouldBeSet()
        {
            Assert.AreEqual(600, car.FuelCapacity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_ProvideEmptyMake_ShouldThrowException(string make)
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car(make, "BMW", 2.3, 600),
                "Make cannot be null or empty!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_ProvideEmptyModel_ShouldThrowException(string model)
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car("1900", model, 2.3, 600),
                "Model cannot be null or empty!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-16)]
        public void When_ProvideFuelConsumptionZeroOrNegative_ShouldThrowException(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car("1900", "BMW", fuelConsumption, 600),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-16)]
        public void When_ProvideFuelCapacityZeroOrNegative_ShouldThrowException(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car("1900", "BMW", 2.3, fuelCapacity),
                "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-16.0)]
        public void When_RefuelWithZeroOrNegativeAmount_ShouldThrowException(double amount)
        {
            Assert.Throws<ArgumentException>(
                () => car.Refuel(amount),
                "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void When_RefuelFuelAmount_ShouldUpdate()
        {
            double fuel = 10;

            car.Refuel(fuel);

            Assert.AreEqual(fuel, car.FuelAmount);
        }

        [Test]
        public void When_RefuelMoreThanCapacityFuel_ShouldBeEqualToCapacity()
        {
            double fuel = 601;

            car.Refuel(fuel);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void When_DriveAndDonNotHaveEnoughFuel_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => car.Drive(10000),
                "You don't have enough fuel to drive!");
        }

        [Test]
        public void When_DriveAndHaveEnoughFuel_AmountOfFuelShouldDecrease()
        {
            car.Refuel(600);
            car.Drive(1);

            Assert.AreNotEqual(600, car.FuelAmount);
        }
    }
}
