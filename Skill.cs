using System;

namespace BoringRPG
{
  abstract class Skill
  {
    public string Name { get; set; }

    public abstract void Use(Archetype caster, Archetype target);
  }
}