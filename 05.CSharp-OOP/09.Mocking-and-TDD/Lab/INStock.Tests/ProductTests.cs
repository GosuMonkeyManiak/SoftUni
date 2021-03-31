using System;
using INStock.Contracts;
using NUnit.Framework;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private IProduct product;
        private string label;
        private int quantity;
        private decimal price;

        [SetUp]
        public void SetUp()
        {
            label = "Pesho";
            quantity = 10;
            price = 10;
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("               ")]
        public void When_ProvideEmptyNullOrWhiteSpaceLabel_ShouldThrowException(string label)
        {
            Assert.Throws<ArgumentException>(
                () => product = new Product(label, quantity, price),
                "Label can't be empty or white space.");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(-42)]
        public void When_ProvideNegativeQuantity_ShouldThrowException(int quantity)
        {
            Assert.Throws<ArgumentException>(
                () => product = new Product(label, quantity, price),
                "Quantity can't be negative number");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-42)]
        public void When_ProvideZeroOrNegativePrice_ShouldThrowException(decimal price)
        {
            Assert.Throws<ArgumentException>(
                () => product = new Product(label, quantity, price),
                "Price can't be zero or negative number");
        }
    }
}