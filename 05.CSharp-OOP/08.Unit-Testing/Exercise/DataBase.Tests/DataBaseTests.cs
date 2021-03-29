using System;
using NUnit.Framework;

namespace DataBase.Tests
{
    public class DatabaseTests
    {
        private Database dataBase;
        private int[] elements;

        [SetUp]
        public void Setup()
        {
            elements = new[] { 1, 2, 3 };
            dataBase = new Database(elements);
        }

        [Test]
        public void When_ProvideNewElement_InSideArray_ShouldHaveThisProvideElement()
        {
            int[] dataBaseElements = dataBase.Fetch();

            for (int i = 0; i < dataBaseElements.Length; i++)
            {
                Assert.AreEqual(elements[i], dataBaseElements[i]);
            }
        }

        [Test]
        public void When_ProvideNewElementCountOfElement_ShouldBeTheSameAsProvided()
        {
            Assert.AreEqual(elements.Length, dataBase.Count);
        }

        [Test]
        public void When_ProvideMoreThan16Element_ShouldThrowException()
        {
            elements = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.That(() =>
            {
                dataBase = new Database(elements);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_AddMoreThen16Element_ShouldThrowException()
        {
            elements = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            dataBase = new Database(elements);

            Assert.That(() =>
            {
                dataBase.Add(17);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_AddElementCount_ShouldIncrease()
        {
            dataBase.Add(4);

            Assert.AreEqual(4, dataBase.Count);
        }

        [Test]
        public void When_AddElementLastElement_ShouldTheSameAsAdded()
        {
            dataBase.Add(4);
            int lastElement = dataBase.Fetch()[dataBase.Count - 1];

            Assert.AreEqual(4, lastElement);
        }

        [Test]
        public void When_DoNotHaveMoreElementAndTryToRemove_ShouldThrowException()
        {
            dataBase = new Database(new int[0]);

            Assert.That(() =>
            {
                dataBase.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void When_RemoveElementCount_ShouldDecrease()
        {
            dataBase.Remove();

            Assert.AreEqual(2, dataBase.Count);
        }

        [Test]
        public void When_RemoveElementLastElement_ShouldBeRemoved()
        {
            int lastOurElement = elements[elements.Length - 1];
            dataBase.Remove();
            int lastDataBaseElement = dataBase.Fetch()[dataBase.Count - 1];

            Assert.AreNotEqual(lastOurElement, lastDataBaseElement);
        }
    }
}
