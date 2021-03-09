using System;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name, 80)
        {

        }

        public override void CastAbility()
        {
            Console.WriteLine($"{this.GetType().Name} - {Name} healed for {Power}");
        }
    }
}