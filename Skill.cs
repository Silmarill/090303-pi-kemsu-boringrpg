using System;

namespace BoringRPG {
  public class Skill {
    public string Name;

    public virtual void Use(Archetype caster, Archetype target)
    {
    }
  }
}