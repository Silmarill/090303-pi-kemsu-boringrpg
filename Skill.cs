using System;

namespace BoringRPG
{
    internal abstract class Skill
    {

        public string Name;
        public int ManaCost;

        public abstract void Use(Archetype caster, Archetype target);

        protected Skill(string name, int manaCost, Archetype target)
        {
            Name = name;
            ManaCost = manaCost;
        }
    }
}