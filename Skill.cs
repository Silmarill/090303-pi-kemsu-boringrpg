using System;
using System.Dynamic;

namespace BoringRPG
{
    internal abstract class Skill
    {
        public string Name;
        public int Mana;

        public abstract void Use(Archetype caster, Archetype target);

        public Skill(string name, int mana)
        {
            Name = name;
            Mana = mana;
        }
    }
}