using System;

namespace BoringRPG
{
    internal class DestinyShuffle : Skill
    {
        private static Random randomParameter = new Random();

        public DestinyShuffle(string name, int mana) : base(name, mana)
        {
        }

        public override void Use(Archetype caster, Archetype target)
        {
            
            
        }
    }
}