using System;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name, 100)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{this.GetType().Name} - {Name} healed for {Power}");
        }
    }
}