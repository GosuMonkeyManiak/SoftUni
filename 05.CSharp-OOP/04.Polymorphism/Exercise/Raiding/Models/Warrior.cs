using System;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) 
            : base(name, 100)
        {

        }

        public override void CastAbility()
        {
            Console.WriteLine($"{this.GetType().Name} - {Name} hit for {Power} damage");
        }
    }
}