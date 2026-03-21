using System;

namespace BoringRPG {
  internal class CoinOfFate : Skill {
    static Random random = new Random();
    int chance;
    int firstChancePoint = 30;
    int secondChancePoint = 60;

    public CoinOfFate() : base("CoinOfFate") { 
    }

    public override void Use(Archetype caster, Archetype target) {
      Console.WriteLine($"\n{caster.Name} подбрасывает Монету судьбы! :О");

      chance = random.Next(100);

      if (chance < firstChancePoint) {
        target.HP = 0;
        Console.WriteLine($"Монета решила, что {target.Name} умрет!" +
                          $"\n{target.Name} умирает . . .");
      } else if (chance < secondChancePoint) {
        caster.HP = 0;
                Console.WriteLine($"Монета решила, что {caster.Name} умрет!" +
                                  $"\n{caster.Name} умирает . . .");
      } else {
        Console.WriteLine("Ничего не произошло: монета упала ребром!");
      }
    }
  }
}
