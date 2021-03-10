using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        private string breed;

        protected Feline(string name, double weight, Food food, string livingRegion, string breed) 
            : base(name, weight, food, livingRegion)
        {
            Breed = breed;
        }

        public string Breed
        {
            get => breed;
            private set => breed = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            int commaIndex = base.ToString().IndexOf(',');

            sb.Insert(commaIndex + 1, $" {Breed},");

            return sb.ToString();
        }
    }
}