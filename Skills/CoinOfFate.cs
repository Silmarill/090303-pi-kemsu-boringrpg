using System;

namespace BoringRPG {
  public class CoinOfFate : Skill {
    private static Random random = new Random();

    public CoinOfFate() : base("Coin of Fate") {
    }

    public override void Use(Archetype caster, Archetype target) {
      int roll = random.Next(1, 101);

      Console.WriteLine($"\n{caster.Name} uses skill {Name}!");
      Console.WriteLine($"Coin of fate is tossed... Result: {roll}");

      if (roll <= 30) {
        target.HP = 0;
        Console.WriteLine($"{target.Name} dies from the blow of fate!");
      }
      else if (roll <= 60) {
        caster.HP = 0;
        Console.WriteLine($"{caster.Name} dies from the blow of fate!");
      }
      else {
        Console.WriteLine($"Nothing happens. Fate is merciful...");
      }
    }
  }
}