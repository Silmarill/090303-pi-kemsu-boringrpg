using System;

namespace BoringRPG.Skills {
  internal class SoulLink : Skill {
    public SoulLink() {
      Name = "Soul Link";
    }

    // This skill links the life forces of the caster and the target, equalizing their HP
    public override string Use(Archetype caster, Archetype target) {
      string result = $"\n[{caster.Name}] use {Name} on [{target.Name}]!";
      int totalHP;

      // Calculate the average HP and set it for both caster and target
      totalHP = caster.HP + target.HP;

      // If either HP is zero, we can't link souls, so we just return
      caster.HP = totalHP / 2;
      target.HP = totalHP / 2;

      result += $"Life forces equalized! Now both have {caster.HP} HP.";

      return result;
    }
  }
}
