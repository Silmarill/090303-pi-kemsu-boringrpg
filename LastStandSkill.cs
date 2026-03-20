using System;

namespace BoringRPG
{
    internal class LastStandSkill : Skill
    {
        public LastStandSkill(string name, int manaCost, Archetype target) : base("Абузер", 10, target)
        {
        }

        public override void Use(Archetype caster, Archetype target){
            if (caster.MP < ManaCost){
                return;
            }
            caster.MP -= ManaCost;
            caster.HP = target.Damage + 2;
        }
    }
}
