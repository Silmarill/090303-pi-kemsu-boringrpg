using System;

namespace BoringRPG {
  public abstract class Skill {
    public string Name;
    internal abstract void Use(Archetype caster, Archetype target);
  }
}
