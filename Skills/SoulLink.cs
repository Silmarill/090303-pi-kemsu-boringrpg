using System;

namespace BoringRPG.Skills {
  internal class SoulLink : Skill {
    public SoulLink() {
    }

    public override void Use(Archetype caster, Archetype target) {
      int resultHP = caster.HP + target.HP;
      int newHP = resultHP / 2;

      caster.HP = newHP;
      target.HP = newHP;
    }
  }
}