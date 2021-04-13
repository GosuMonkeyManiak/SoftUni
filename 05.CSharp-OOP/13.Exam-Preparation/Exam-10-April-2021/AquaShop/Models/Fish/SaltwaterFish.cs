namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish

    {
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.Size = 5;
        }

        public override void Eat()
        {
            base.Eat();
            base.Size += 1;
        }
    }
}