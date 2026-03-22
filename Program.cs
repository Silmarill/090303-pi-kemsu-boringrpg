using BoringRPG.Skills;
using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      var artur = new Necromancer("Artur");
      var dummy = new DummyClass("Dummy");

      Console.WriteLine("Before Fight\n" +
        $"{artur.GetInfo()}" +
        $"{dummy.GetInfo()}"
        );

      Console.WriteLine("\n!!! FIGHT !!! >:)\n");

      // Init skills
      Skill soulLink = new SoulLink();
      Skill drama = new DramaAction();
      Skill coin = new CoinOfFate();

      // SoulLink
      artur.UseSkill(soulLink, dummy);

      // DramaAction
      dummy.UseSkill(drama, artur);

      // CoinOfFate
      artur.UseSkill(coin, dummy);

      Console.WriteLine("\nAfter skill using\n\n" +
      $"{artur.GetInfo()}" +
      $"{dummy.GetInfo()}"
      );

      Console.WriteLine("\nTest is over. Press any button...");
      Console.ReadKey();
    }
  }
}