using System;

namespace BoringRPG {
  // 30% — переименовать противника в "Побеждённый / Легендарный"
  // 30% — переименовать себя в "Легендарный / Побеждённый"
  // 40% — вывести сообщение "{Name} дарит розу {target.Name}"
  internal class DramaAction : Skill {
    private static Random random = new Random();

    public DramaAction() { Name = "DramaAction"; }

    public override void Use(Archetype caster, Archetype target) {
      double roll = random.NextDouble();

      if (roll < 0.30) {
        target.Name = "Побеждённый / Легендарный";
        Console.WriteLine("[DramaAction] Противник отныне известен как \"" + target.Name + "\"!");
      } else if (roll < 0.60) {
        caster.Name = "Легендарный / Побеждённый";
        Console.WriteLine("[DramaAction] Герой отныне известен как \"" + caster.Name + "\"!");
      } else {
        Console.WriteLine("[DramaAction] " + caster.Name + " дарит розу " + target.Name);
      }
    }
  }
}
