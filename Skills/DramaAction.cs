using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A humorous skill that changes character names
namespace BoringRPG {
  internal class DramaAction : Skill {
    private static Random random = new Random();

    public DramaAction() {
      Name = "Drama Action";
    }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n[{caster.Name}] cast {Name}!");
      int roll = random.Next(1, 101);

      // Swap names with a 1% chance
      if (roll == 100) {
        string tempName = caster.Name;
        caster.Name = target.Name;
        target.Name = tempName;
        Console.WriteLine("NO WAY! The characters mixed up their roles and swapped names!");
      }
      // 30% rename target
      else if (roll <= 30) {
        target.Name = "Trolled " + target.Name;
        Console.WriteLine($"The enemy trolled! Now he is called {target.Name}. XD");
      }
      
      // 30% rename caster
      else if (roll <= 60) {
        caster.Name = "Bruh " + caster.Name;
        Console.WriteLine($"Caster tried to troll {target.Name}, but the target had a... Flip-card??? The caster is now named {caster.Name}.");
      }

      // 39% Show message
      else {
        Console.WriteLine($"\n[{caster.Name}] got 'Технические шоколадки'. [{target.Name}] confused.");
      }
    }
  }
}