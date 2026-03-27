using System;

namespace BoringRPG {
  public class SoulLink : Skill { 
    public SoulLink() {
      Name = "SoulLink";
    }

    internal override void Use(Archetype caster, Archetype target) {
      int totalHp = caster.HP + target.HP;
      int newHp = totalHp / 2;

      caster.HP = newHp;
      target.HP = newHp;
    }
  }
}