using System;

namespace BoringRPG.Skills
{
  internal abstract class Skill
  {
    public string Name;

    protected Skill(string name)
    {
      Name = name;
    }

    public abstract void Use(Archetype caster, Archetype target);
  }
}