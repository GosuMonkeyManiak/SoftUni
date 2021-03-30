using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deathDummy;
        private int health;
        private int experience;

        [SetUp]
        public void SetUp()
        {
            this.health = 5;
            this.experience = 5;
            dummy = new Dummy(health, experience);
            deathDummy = new Dummy(0, experience);
        }

        [Test]
        public void When_HealthProvided_ShouldBeSet()
        {
            Assert.AreEqual(health, dummy.Health);
        }

        [Test]
        public void When_DummyWasAttacked_ShouldBeDecreaseHealth()
        {
            int attackPoints = 2;

            dummy.TakeAttack(attackPoints);

            Assert.AreEqual(health - attackPoints, dummy.Health);
        }

        [Test]
        public void When_WasAttackedAndDeath_ShouldException()
        {
            int attackPoints = 2;

            Assert.That(() =>
            {
                deathDummy.TakeAttack(attackPoints);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void When_IsDead_ShouldGiveExperience()
        {
            int givenExperience = deathDummy.GiveExperience();

            Assert.AreEqual(experience, givenExperience);
        }

        [Test]
        public void When_IsNotDeadCantGiveExperience_ShouldException()
        {
            Assert.That(() =>
            {
                dummy.GiveExperience();
            }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }

        [Test]
        public void When_HealthIsZero_ShouldBeDead()
        {
            Assert.That(deathDummy.IsDead);
        }
    }
}