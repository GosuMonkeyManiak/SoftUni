using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    public class HeroTests
    {
        private Mock<IWeapon> weapon;
        private Mock<ITarget> target;
        private Hero hero;

        [SetUp]
        public void SetUp()
        {
            weapon = new Mock<IWeapon>();
            target = new Mock<ITarget>();
            hero = new Hero("Pesho", weapon.Object);
        }

        [Test]
        public void Ctor_ProvideNameAndWeapon_ShouldBeSet()
        {
            Assert.AreEqual("Pesho", hero.Name);
            Assert.IsNotNull(hero.Weapon);
            Assert.AreEqual(0, hero.Experience);
        }

        [Test]
        public void When_TargetIsDead_ShouldReceiveExperience()
        {
            target.Setup(d => d.IsDead()).Returns(true);
            target.Setup(e => e.GiveExperience()).Returns(10);

            hero.Attack(target.Object);

            Assert.AreEqual(10, hero.Experience);
        }
    }
}