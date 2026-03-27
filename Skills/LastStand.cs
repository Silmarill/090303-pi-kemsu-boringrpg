using System;

namespace BoringRPG {
  public class LastStand : Skill {
    public LastStand() {
      Name = "LastStand";
    }

    internal override void Use(Archetype caster, Archetype target) {
      caster.HP = target.Damage + 1;
    }
  }
}