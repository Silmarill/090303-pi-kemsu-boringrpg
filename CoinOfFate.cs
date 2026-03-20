using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class CoinOfFate : Skill {
    private static Random random = new Random();

    public CoinOfFate() : base("CoinOfFate") { }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n{caster.Name} использует {Name} на {target.Name}!");

      int chance = random.Next(100); 

      if (chance < 30) { 
        target.HP = 0;
        Console.WriteLine($" Несчастный случай! {target.Name} погибает!");
      } else if (chance < 60) { 
        caster.HP = 0;
         Console.WriteLine($"Судьба жестока! {caster.Name} погибает!");
      } else { 
        Console.WriteLine($"Ничего не произошло. Повезло!");
      }
    }
  }
}
