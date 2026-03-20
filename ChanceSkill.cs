using System;

namespace BoringRPG
{
    internal class ChanceSkill : Skill
    {
        public ChanceSkill(string name, int manaCost, Archetype target) : base("РАНДОМЕР", 20, target)
        {
        }

        private static Random random = new Random();
        public override void Use(Archetype caster, Archetype target)
        {
            if (caster.MP < ManaCost)
            {
                return;
            }
            caster.HP = random.Next(200);
            caster.MP = random.Next(200);
            caster.Damage = random.Next(50);
            target.HP = random.Next(200);
            target.MP = random.Next(200);
            target.Damage = random.Next(50);
        }
    }
}
