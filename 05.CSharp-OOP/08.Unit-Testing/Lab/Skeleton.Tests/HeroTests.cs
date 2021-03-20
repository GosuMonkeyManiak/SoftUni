using Moq;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        private Hero hero;
        private IWeapon weapon;
        //private ITarget target;

        [SetUp]
        public void Test1()
        {
            weapon = new Axe(2, 10);

            hero = new Hero("Pesho", weapon);
        }

        [Test]
        public void When_TargetDeadHero_ShouldGainExperience()
        {
            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(e => e.GiveExperience()).Returns(20);
            target.Setup(d => d.IsDead()).Returns(true);

            hero.Attack(target.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }
}