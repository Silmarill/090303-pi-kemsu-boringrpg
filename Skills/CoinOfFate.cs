using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class CoinOfFate : Skill {

    // Using only for random rolls in this skill
    private static Random random = new Random();

    public CoinOfFate() {
      // So creative naming :D
      Name = "Coin Of Fate";
    }

    // Skill logic
    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n[{caster.Name}] flip {Name}...");
      int roll = random.Next(1, 101);

      // 30% - Enemy dies
      if (roll <= 30) {
        target.HP = 0;
        Console.WriteLine($"Tails! [{target.Name}] dies instantly!");
      }
      // 60% - Caster dies
      else if (roll <= 60) {
        caster.HP = 0;
        Console.WriteLine($"Eagle! [{caster.Name}] dies instantly!");
      }
      // 30% - Nothing happens (actually, in reality, that would look very surprising)
      else {
        Console.WriteLine($"The coin landed on its edge. Nothing happened.");
      }
    }
  }
}