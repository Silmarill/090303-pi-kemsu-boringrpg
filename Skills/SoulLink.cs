using System;

namespace BoringRPG {
  internal class SoulLink : Skill {
    static Random random = new Random();
    int totalHP;
    int sharedHP;

    public SoulLink() : base("SoulLink") {
    }

    public override void Use(Archetype caster, Archetype target) {

      totalHP = caster.HP + target.HP;
      sharedHP = totalHP / 2;
      
      caster.HP = sharedHP;
      target.HP = sharedHP;
    }
  }
}
