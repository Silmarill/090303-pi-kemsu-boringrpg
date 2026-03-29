using System;

namespace BoringRPG {
  internal class ComplimentEnemy : Skill {
    public override void Use(Archetype caster, Archetype target) {
      target.Damage += 10;
      target.CritChance += 0.2;
      Console.WriteLine($"{caster.Name} похвалил {target.Name}");
    }
  }
}
