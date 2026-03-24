using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class ManaDrain : Skill {
    public ManaDrain() : base("Высасывание маны") {
    }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n=== {caster.Name} использует навык: {Name} ===");

      int drainAmount = target.MP / 2; // Забираем половину маны цели

      if (drainAmount > 0) {
        target.MP -= drainAmount;
        caster.MP += drainAmount;

        Console.WriteLine($"{caster.Name} высасывает {drainAmount} MP у {target.Name}!");
        Console.WriteLine($"{caster.Name} получает +{drainAmount} MP (теперь: {caster.MP})");
        Console.WriteLine($"{target.Name} теряет {drainAmount} MP (теперь: {target.MP})");
      }
      else {
        Console.WriteLine($"У {target.Name} нет маны для высасывания!");
      }
      Console.WriteLine();
    }
  }
}