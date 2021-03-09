using System;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name, 80)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{this.GetType().Name} - {Name} hit for {Power} damage");
        }
    }
}