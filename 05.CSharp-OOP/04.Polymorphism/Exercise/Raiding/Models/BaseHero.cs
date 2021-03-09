namespace Raiding.Models
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public int Power
        {
            get => power;
            private set => power = value;
        }

        public abstract void CastAbility();
    }
}
