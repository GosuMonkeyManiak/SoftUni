using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        protected Bird(string name, double weight, Food food, double wingSize) 
            : base(name, weight, food)
        {
            WingSize = wingSize;
        }

        public double WingSize
        {
            get => wingSize;
            private set => wingSize = value;
        }

        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}