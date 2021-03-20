namespace Skeleton.Contracts
{
    public interface ITarget
    {
        int Health { get; }

        public void TakeAttack(int attackPoints);

        public int GiveExperience();

        public bool IsDead();
    }
}