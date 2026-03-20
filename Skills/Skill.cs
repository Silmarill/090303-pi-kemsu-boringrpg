using System;

namespace BoringRPG {
  public abstract class Skill {
    public string Name { get; protected set; }

    protected Skill(string name) {
      Name = name;
    }

    public abstract void Use(Archetype caster, Archetype target);
  }
}