using System;

namespace BoringRPG {
  public class DramaAction : Skill {
    private static Random random = new Random();

    public DramaAction() : base("Drama Action") {
    }

    public override void Use(Archetype caster, Archetype target) {
      int roll = random.Next(1, 101);

      Console.WriteLine($"\n{caster.Name} uses skill {Name}!");
      Console.WriteLine($"Result: {roll}");

      if (roll <= 30) {
        string oldName = target.Name;
        target.Name = "Defeated " + oldName;
        Console.WriteLine($"{oldName} is now called {target.Name}!");
      }
      else if (roll <= 60) {
        string oldName = caster.Name;
        caster.Name = "Legendary " + oldName;
        Console.WriteLine($"{oldName} is now called {caster.Name}!");
      }
      else {
        Console.WriteLine($"{caster.Name} gives a rose to {target.Name}!");
      }
    }
  }
}