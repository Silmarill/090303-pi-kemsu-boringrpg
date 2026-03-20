using System;

namespace BoringRPG {
  public class SoulLink : Skill {
    public SoulLink() : base("Soul Link") {
    }

    public override void Use(Archetype caster, Archetype target) {
      int totalHp = caster.HP + target.HP;
      int newHp = totalHp / 2;

      Console.WriteLine($"\n{caster.Name} uses skill {Name}!");
      Console.WriteLine($"Souls of {caster.Name} and {target.Name} are linked!");

      caster.HP = newHp;
      target.HP = newHp;

      Console.WriteLine($"Now both have {newHp} HP!");
    }
  }
}