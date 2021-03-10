using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        protected Mammal(string name, double weight, Food food, string livingRegion) 
            : base(name, weight, food)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get => livingRegion;
            private set => livingRegion = value;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {livingRegion}, {FoodEaten}]";
        }
    }
}