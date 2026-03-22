using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG.Skills {
  internal class SoulLink : Skill {
    public SoulLink() {
      Name = "Soul Link";
    }

    // This skill links the life forces of the caster and the target, equalizing their HP
    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n[{caster.Name}] use {Name} on [{target.Name}]!");

      // Calculate the average HP and set it for both caster and target
      int totalHP = caster.HP + target.HP;

      // If either HP is zero, we can't link souls, so we just return
      caster.HP = totalHP / 2;
      target.HP = totalHP / 2;

      Console.WriteLine($"Life forces equalized! Now both have {caster.HP} HP.");
    }
  }
}
