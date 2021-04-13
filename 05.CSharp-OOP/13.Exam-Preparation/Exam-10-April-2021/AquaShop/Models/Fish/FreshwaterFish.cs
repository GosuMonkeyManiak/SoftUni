namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.Size = 3;
        }

        public override void Eat()
        {
            base.Eat();
            base.Size += 2;
        }
    }
}