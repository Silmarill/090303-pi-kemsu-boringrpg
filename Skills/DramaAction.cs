using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class DramaAction : Skill {
    private static Random random = new Random();

    public DramaAction() : base("Драматическое действие") {
    }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n=== {caster.Name} использует навык: {Name} ===");

      int chance = random.Next(100);

      if (chance < 30) // 30% - переименовать противника
      {
        string oldName = target.Name;
        target.Name = $"Побеждённый {oldName}";
        Console.WriteLine($"{oldName} теперь называется {target.Name}!");
      }
      else if (chance < 60) // 30% - переименовать себя
      {
        string oldName = caster.Name;
        caster.Name = $"Легендарный {oldName}";
        Console.WriteLine($"{oldName} теперь называется {caster.Name}!");
      }
      else // 40% - романтический жест
      {
        Console.WriteLine($"{caster.Name} дарит розу {target.Name} ♥");
      }
      Console.WriteLine();
    }
  }
}