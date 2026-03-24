using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class SoulLink : Skill {
    public SoulLink() : base("Связь душ") {
    }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n=== {caster.Name} использует навык: {Name} ===");

      int totalHP = caster.HP + target.HP;
      int newHP = totalHP / 2;

      Console.WriteLine($"До применения: {caster.Name} (HP: {caster.HP}), {target.Name} (HP: {target.HP})");

      caster.HP = newHP;
      target.HP = newHP;

      Console.WriteLine($"Души связаны! HP выровнены до {newHP}");
      Console.WriteLine($"После применения: {caster.Name} (HP: {caster.HP}), {target.Name} (HP: {target.HP})\n");
    }
  }
}