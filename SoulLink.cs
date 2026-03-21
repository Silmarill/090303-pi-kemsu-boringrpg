using System;

namespace BoringRPG {
  internal class SoulLink : Skill {
    static Random random = new Random();
    int totalHP;
    int sharedHP;

    public SoulLink() : base("SoulLink") {
    }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n{caster.Name} использует навык {Name} на {target.Name}");

      totalHP = caster.HP + target.HP;
      sharedHP = totalHP / 2;

      Console.WriteLine($"Общее здоровье {totalHP} ушло поровну каждому");
      
      caster.HP = sharedHP;
      target.HP = sharedHP;
    }
  }
}
