using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attackPoints = 5;
        private int durabilityPoints = 5;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(500, 500);
        }

        [Test]
        public void When_AttackPointsIsProvided_ShouldBeSet()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints, "Attack Points doesn't set");
        }

        [Test]
        public void When_DurabilityPointsIsProvided_ShouldBeSet()
        {
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints, "Durability Points doesn't set");
        }

        [Test]
        public void When_Attacked_ShouldDecreaseDurability()
        {
            axe.Attack(dummy);

            Assert.AreEqual(this.durabilityPoints - 1, axe.DurabilityPoints);
        }

        [Test]
        public void When_AttackedWithBrokenWeapon_ShouldException()
        {
            axe = new Axe(10, 0);

            Assert.That(() =>
            {
                axe.Attack(dummy);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
