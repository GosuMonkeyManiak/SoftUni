using System;
using NUnit.Framework;

namespace DatabaseExtended.Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase dataBase;
        private Person[] people;

        [SetUp]
        public void Setup()
        {
            people = new Person[16];
            dataBase = new ExtendedDatabase();
        }

        [Test]
        public void When_ProvideIntoConstructorMoreThen16People_ShouldTrowException()
        {
            people = new Person[17];

            Assert.That(() =>
            {
                dataBase = new ExtendedDatabase(people);
            }, Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void When_ProvideIntoConstructorPeople_CountShouldIncrease()
        {
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"{i}");
            }

            dataBase = new ExtendedDatabase(people);

            Assert.AreEqual(people.Length, dataBase.Count);
        }

        [Test]
        public void When_ProvideIntoConstructorPerson_ShouldBeSet()
        {
            dataBase = new ExtendedDatabase(new Person(1, "1"));

            Person person = dataBase.FindById(1);

            Assert.AreEqual(1, person.Id);
        }

        [Test]
        public void When_TryToAdd17Person_ShouldTrowException()
        {
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"{i}");
            }

            dataBase = new ExtendedDatabase(people);

            Assert.That(() =>
            {
                dataBase.Add(new Person(17, "17"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_AddAlreadyExistPersonWithUserName_ShouldThrowException()
        {
            dataBase.Add(new Person(1, "1"));

            Assert.That(() =>
            {
                dataBase.Add(new Person(1, "1"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void When_AddAlreadyExistPersonWithId_ShouldThrowException()
        {
            dataBase.Add(new Person(1, "1"));

            Assert.That(() =>
            {
                dataBase.Add(new Person(1, "2"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void When_AddPerson_CountShouldIncrease()
        {
            dataBase.Add(new Person(1, "1"));

            Assert.AreEqual(1, dataBase.Count);
        }

        [Test]
        public void When_AddPerson_ThePersonShouldBeAdded()
        {
            dataBase.Add(new Person(1, "1"));

            Person person = dataBase.FindById(1);

            Assert.AreEqual(1, person.Id);
        }

        [Test]
        public void When_DoNotHavePeople_RemoveShouldThrowException()
        {
            dataBase.Add(new Person(1, "1"));
            dataBase.Remove();

            Assert.That(() =>
            {
                dataBase.Remove();
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void When_Remove_PersonShouldBeRemoved()
        {
            dataBase.Add(new Person(1, "1"));

            dataBase.Remove();

            Assert.That(() =>
            {
                dataBase.FindById(1);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void When_Remove_CountShouldDecrease()
        {
            dataBase.Add(new Person(1, "1"));
            dataBase.Remove();

            Assert.AreEqual(0, dataBase.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_FindByEmptyUsername_ShouldThrowException(string userName)
        {
            Assert.That(() =>
            {
                Person person = dataBase.FindByUsername(userName);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void When_FindByNotExistingUsername_ShouldTrowException()
        {
            Assert.That(() =>
            {
                dataBase.FindByUsername("Pesho");
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void When_FindByUsername_ShouldReturnUserWithThatUsername()
        {
            dataBase.Add(new Person(1, "Pesho"));

            Person person = dataBase.FindByUsername("Pesho");

            Assert.AreEqual("Pesho", person.UserName);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-28)]
        public void When_FindByNegativeId_ShouldThrowException(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => dataBase.FindById(id));
        }

        [Test]
        public void When_FindByNotExistingId_ShouldThrowException()
        {
            Assert.That(() =>
            {
                dataBase.FindById(1);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void When_FindById_ShouldReturnPersonWithThatId()
        {
            dataBase.Add(new Person(1, "1"));

            Person person = dataBase.FindById(1);

            Assert.AreEqual(1, person.Id);
        }
    }
}
