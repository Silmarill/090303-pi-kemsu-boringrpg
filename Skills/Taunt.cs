using System;

namespace BoringRPG {
  public class Taunt : Skill {
    public Taunt() {
      Name = "Taunt";
    }
    internal override void Use(Archetype caster, Archetype target) {
      double oldCrit = target.CritChance;
      target.CritChance *= 0.5;
    }
  }
}