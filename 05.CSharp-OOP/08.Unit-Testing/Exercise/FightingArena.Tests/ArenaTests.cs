using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private List<Warrior> warriors;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warriors = new List<Warrior>
            {
                new Warrior("Achilles", 120, 240),
                new Warrior("Hector", 130, 260),
                new Warrior("Thor", 180, 360)
            };
        }

        [Test]
        public void CheckIfIReadOnlyCollectionOfWarriorsWorksProperly()
        {
            this.EnrollDefaultWarriors();
            var expectedCollection = this.warriors;
            var actualCollection = this.arena.Warriors;

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void CheckIfEnrollWorksProperly()
        {
            this.EnrollDefaultWarriors();

            var expectedCount = 3;
            var actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase("Achilles", 499, 781)]
        [TestCase("Hector", 888, 292)]
        [TestCase("Thor", 1282, 999)]
        public void EnrollShouldThrowExceptionWhenThereIsSuchWarrior
            (string name, int damage, int hp)
        {
            this.EnrollDefaultWarriors();

            var warrior = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }

        [Test]
        public void CheckIfAttackWorksProperly()
        {
            this.EnrollDefaultWarriors();
            var attacker = this.arena.Warriors.First(w => w.Name == "Achilles");
            var defender = this.arena.Warriors.First(w => w.Name == "Hector");

            var expectedHp = defender.HP - attacker.Damage;

            if (expectedHp < 0)
            {
                expectedHp = 0;
            }

            this.arena.Fight("Achilles", "Hector");

            var actualHp = defender.HP;

            Assert.AreEqual(expectedHp, actualHp);

        }

        [TestCase(null, "Hector")]
        [TestCase("Achilles", null)]

        public void FightShouldThrowExceptionWhenInvalidPlayer(string attacker, string defender)
        {
            this.EnrollDefaultWarriors();
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker, defender);
            });
        }
        private void EnrollDefaultWarriors()
        {
            foreach (var warrior in this.warriors)
            {
                this.arena.Enroll(warrior);
            }
        }
    }
}
