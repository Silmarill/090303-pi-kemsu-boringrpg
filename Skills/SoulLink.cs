using System;

namespace BoringRPG
{
    internal class SoulLink : Skill
    {
        public SoulLink()
        {
            Name = "Soul Link";
        }

        public override void Use(Archetype caster, Archetype target)
        {
            int totalHp = caster.HP + target.HP;
            int newHp = totalHp / 2;

            caster.HP = newHp;
            target.HP = newHp;

            Console.WriteLine($"{caster.Name} использует {Name}: HP обоих становится {newHp}");
        }
    }
}