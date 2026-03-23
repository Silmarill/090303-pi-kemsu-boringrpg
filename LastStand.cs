using System;

namespace BoringRPG
{
    internal class LastStand : Skill
    {
        public LastStand()
        {    
        }

        public override void Use(Archetype caster, Archetype target)
        {
            caster.HP = target.Damage + 1;
        }
    }
}