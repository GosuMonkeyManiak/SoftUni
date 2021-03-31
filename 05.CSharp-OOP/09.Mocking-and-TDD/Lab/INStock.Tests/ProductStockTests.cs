using System;
using System.Collections.Generic;
using INStock.Contracts;
using Moq;
using NUnit.Framework;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductStockTests
    {
        private ITrackingSystem trackingSystem;
        private Mock<IProduct> product;
        private string label;

        [SetUp]
        public void SetUp()
        {
            label = "apple";
            trackingSystem = new TrackingSystem();
            product = new Mock<IProduct>();
            product.Setup(l => l.Label).Returns(label);
            product.Setup(q => q.Quantity).Returns(1);
            product.Setup(p => p.Price).Returns(10);
        }

        [Test]
        public void When_MakeNewTrackingSystem_CountOfProductShouldBeZero()
        {
            Assert.AreEqual(0, trackingSystem.Count);
        }

        [Test]
        public void When_AddProduct_ProductShouldBeAdded()
        {
            trackingSystem.Add(product.Object);

            Assert.AreEqual(1, trackingSystem.Count);
        }

        [Test]
        public void When_AddProductWithExistingLabel_ShouldThrowException()
        {
            Mock<IProduct> secondProduct = new Mock<IProduct>();
            secondProduct.Setup(l => l.Label).Returns(label);

            trackingSystem.Add(product.Object);

            Assert.Throws<ArgumentException>(
                () => trackingSystem.Add(secondProduct.Object),
                "That product is exist!");
        }

        [Test]
        public void When_CheckForExistProduct_ShouldReturnTrue()
        {
            trackingSystem.Add(product.Object);

            Assert.IsTrue(trackingSystem.Contains(product.Object));
        }

        [Test]
        public void When_CheckForNotExistProduct_ShouldReturnFalse()
        {
            Assert.IsFalse(trackingSystem.Contains(product.Object));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(5)]
        public void When_FindByInvalidIndex_ShouldThrowException(int index)
        {
            trackingSystem.Add(product.Object);

            Assert.Throws<IndexOutOfRangeException>(
                () => trackingSystem.Find(index),
                "Index was out of range!");
        }

        [Test]
        public void When_FindByIndex_ShouldReturnProduct()
        {
            trackingSystem.Add(product.Object);

            IProduct currentProduct = trackingSystem.Find(0);

            Assert.IsNotNull(currentProduct);
        }

        [Test]
        public void When_FindByLabelNotExistProduct_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => trackingSystem.FindByLabel(label),
                "The product does't exist!");
        }

        [Test]
        public void When_FindByLabelExistProduct_ShouldReturnThatProduct()
        {
            trackingSystem.Add(product.Object);

            IProduct currentProduct = trackingSystem.FindByLabel(label);

            Assert.IsNotNull(currentProduct);
        }

        [Test]
        public void When_FindByPriceRange_ShouldReturnCollectionOfProducts()
        {
            Mock<IProduct> secondProduct = new Mock<IProduct>();
            secondProduct.Setup(l => l.Label).Returns("orange");
            secondProduct.Setup(p => p.Price).Returns(1);

            trackingSystem.Add(product.Object);
            trackingSystem.Add(secondProduct.Object);

            List<IProduct> producsInPriceRange = trackingSystem.FindAllInPriceRange(1, 10);

            Assert.AreEqual(2, producsInPriceRange.Count);
        }

        [Test]
        public void When_FindByPriceRange_AndDoNotHaveProduct_ShouldReturnEmptyCollection()
        {
            List<IProduct> emptyCollection = trackingSystem.FindAllInPriceRange(1, 10);

            Assert.IsNotNull(emptyCollection);
        }

        [Test]
        public void When_FindAllByPrice_ShouldReturnCollectionOfProductsWithThatPrice()
        {
            Mock<IProduct> secondProduct = new Mock<IProduct>();
            secondProduct.Setup(l => l.Label).Returns("orange");
            secondProduct.Setup(p => p.Price).Returns(10);

            trackingSystem.Add(product.Object);
            trackingSystem.Add(secondProduct.Object);

            List<IProduct> productsByPrice = trackingSystem.FindAllByPrice(10);


            Assert.AreEqual(2, productsByPrice.Count);
        }

        [Test]
        public void When_FindAllByPrice_AndDoNotHaveProductWithThatPrice_ShouldReturnEmptyCollection()
        {
            List<IProduct> productsByPrice = trackingSystem.FindAllByPrice(10);

            Assert.IsNotNull(productsByPrice);
        }

        [Test]
        public void When_FindAllByQuantity_ShouldReturnCollectionOfProductWithThatQuantity()
        {
            trackingSystem.Add(product.Object);

            List<IProduct> productsByQuantity = trackingSystem.FindAllByQuantity(1);

            Assert.AreEqual(1, productsByQuantity.Count);
        }

        [Test]
        public void When_FindAllByQuantity_AndDoNotHaveProductsWithThatQuantity_ShouldReturnEmptyCollection()
        {
            List<IProduct> productsByQuantity = trackingSystem.FindAllByQuantity(10);

            Assert.IsNotNull(productsByQuantity);
        }

        [Test]
        public void When_GetByIndexer_ShouldReturnProductOnThatIndex()
        {
            trackingSystem.Add(product.Object);

            IProduct currentProduct = trackingSystem[0];

            Assert.IsNotNull(currentProduct);
        }

        [Test]
        public void When_SetByIndexer_ShouldBeSet()
        {
            Mock<IProduct> secondProduct = new Mock<IProduct>();
            secondProduct.Setup(l => l.Label).Returns("orange");

            trackingSystem.Add(product.Object);

            trackingSystem[0] = secondProduct.Object;

            IProduct currentProduct = trackingSystem[0];

            Assert.AreEqual("orange", currentProduct.Label);
        }

        [Test]
        public void When_FindMostExpensiveProduct_ShouldReturnIt()
        {
            Mock<IProduct> secondProduct = new Mock<IProduct>();
            secondProduct.Setup(l => l.Label).Returns("orange");
            secondProduct.Setup(p => p.Price).Returns(12);

            trackingSystem.Add(product.Object);
            trackingSystem.Add(secondProduct.Object);

            IProduct currentProduct = trackingSystem.FindMostExpensiveProducts();

            Assert.AreEqual(12, currentProduct.Price);
            Assert.AreEqual("orange", currentProduct.Label);
        }

        [Test]
        public void When_FindMostExpensiveProduct_AndThatProductNotExist_ShouldReturnEmptyProduct()
        {
            IProduct currentProduct = trackingSystem.FindMostExpensiveProducts();

            Assert.IsNull(currentProduct);
        }
    }
}
