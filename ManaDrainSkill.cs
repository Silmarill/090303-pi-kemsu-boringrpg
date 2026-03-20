using System;

namespace BoringRPG
{
    internal class ManaDrainSkill : Skill
    {
        public ManaDrainSkill(string name, int manaCost, Archetype target) : base("Вор манки", 2, target)
        {
        }

        public override void Use(Archetype caster, Archetype target)
        {
            if (caster.MP < ManaCost)
            {
                return;
            }

            caster.MP -= ManaCost;
            target.MP -= 10;
            caster.MP += 10;
            if (target.MP < 0)
            {
                target.MP = 0;
            }
        }
    }
}
