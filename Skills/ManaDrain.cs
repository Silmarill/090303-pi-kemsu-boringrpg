using System;

namespace BoringRPG
{
    internal class ManaDrain : Skill
    {
        public ManaDrain()
        {
            Name = "Mana Drain";
        }

        public override void Use(Archetype caster, Archetype target)
        {
            const int drainAmount = 10; 
            int actualDrain = Math.Min(drainAmount, target.MP); // не больше, чем есть у цели

            target.MP -= actualDrain;
            caster.MP += actualDrain;

            Console.WriteLine($"{caster.Name} использует {Name}: высасывает {actualDrain} MP у {target.Name} и получает их себе.");
        }
    }
}