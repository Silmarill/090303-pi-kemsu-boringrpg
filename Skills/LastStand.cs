using System;

namespace BoringRPG {
  public class LastStand : Skill {
    public LastStand() {
      Name = "LastStand";
    }

    internal override void Use(Archetype caster, Archetype target) {
      caster.HP = target.Damage + 1;

      Console.WriteLine($"{caster.Name} использует LastStand! HP = урону противника + 1 ({caster.HP:F1} HP).");
    }
  }
}