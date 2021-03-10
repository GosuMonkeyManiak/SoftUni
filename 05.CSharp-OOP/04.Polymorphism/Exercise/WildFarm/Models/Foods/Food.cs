namespace WildFarm.Models.Foods
{
    public abstract class Food
    {
        private int foodQuantity;

        protected Food(int foodQuantity)
        {
            FoodQuantity = foodQuantity;
        }

        public int FoodQuantity
        {
            get => foodQuantity;
            private set => foodQuantity = value;
        }
    }
}
