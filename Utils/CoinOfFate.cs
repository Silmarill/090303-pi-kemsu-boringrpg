using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class CoinOfFate : Skill {
    private static Random random = new Random();

    public CoinOfFate() : base("CoinOfFate") { }
    string result = $"\n{caster.Name} использует {Name} на {target.Name}!";

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n{caster.Name} использует {Name} на {target.Name}!");

      int chance = random.Next(100); 

      if (chance < 30) { 
        target.HP = 0;
        result += $"\nНесчастный случай! {target.Name} погибает!";
      } else if (chance < 60) { 
        caster.HP = 0;
        result += $"\nСудьба жестока! {caster.Name} погибает!";
      } else { 
        Console.WriteLine($"Ничего не произошло. Повезло!");
      }
    }
  }
}
