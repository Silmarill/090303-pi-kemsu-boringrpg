using System;

namespace BoringRPG {
  internal class DramaAction : Skill {
    static Random random = new Random();
    int chance;
    int firstChancePoint = 30;
    int secondChancePoint = 60;

    public DramaAction() : base("DramaAction") { 
    }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n{caster.Name} использует навык {Name} на {target.Name}");

      chance = random.Next(100);

      if (chance < firstChancePoint) { 
        string oldName = target.Name;
        target.Name = "Побежденный" + oldName;
        Console.WriteLine($"{oldName} переименован в {target.Name}");
      } else if (chance < secondChancePoint) { 
        string oldName = caster.Name;
        caster.Name = "Легендарный" + oldName;
        Console.WriteLine($"{oldName} переименован в {caster.Name}");
      } else { 
        Console.WriteLine($"{caster.Name} дарит розу {target.Name}");
      }
    }
  }
}
