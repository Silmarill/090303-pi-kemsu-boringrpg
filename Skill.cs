using System;

namespace BoringRPG {
  public abstract class Skill {
    public string Name;

    public abstract void Use(Archetype caster, Archetype target);
  }
}