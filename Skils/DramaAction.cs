using System;

namespace BoringRPG {
  internal class DramaAction : Skill {
    private static Random random = new Random();

    public DramaAction() : base("DramaAction") {
    }

    public override void Use (Archetype caster, Archetype target) {
      int chance = random.Next(100); // 100%

      if (chance < 30) { // 30% – переименовать противника
        target.Name = "Побеждённый " + target.Name;
        Console.WriteLine($"{caster.Name} использует {Name}: {target.Name} теперь зовётся \"{target.Name}\"!");
      } else if (chance < 60) { // 30% – переименовать себя
        caster.Name = "Легендарный " + caster.Name;
        Console.WriteLine($"{caster.Name} использует {Name}: теперь он зовётся \"{caster.Name}\"!");
      } else { // 40% – роза
        Console.WriteLine($"{caster.Name} дарит розу {target.Name} ");
      }
    }
  }
}