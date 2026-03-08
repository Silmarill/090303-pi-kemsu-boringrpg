using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Lancelot is clever");
      DummyClass artur = new DummyClass("Arthur Pendragon");
      Paladin paladin = new Paladin("Mateus Paladinov");
      Console.WriteLine($"BEGINNING OF THE BATTLE. Initial state: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n" +
                        $"{paladin.GetInfo()}\n");


      Console.WriteLine($"{lancelot.Name} attacks {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? "- CRITICAL HIT!" : "";

      Console.WriteLine($"Damage {damage} dealt {critText}\n");


      Console.WriteLine($"{paladin.Name} attacks {lancelot.Name}!");

      beforeHP = lancelot.HP;
      paladin.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = paladin.LastHitWasCrit ? "- CRITICAL HIT!" : "";

      Console.WriteLine($"Damage {damage} dealt {critText}\n");


      Console.WriteLine($"{artur.Name} attacks {paladin.Name}!");

      beforeHP = paladin.HP;
      artur.Hit(paladin);
      damage = beforeHP - paladin.HP;

      critText = artur.LastHitWasCrit ? "- CRITICAL HIT!" : "";

      Console.WriteLine($"Damage {damage} dealt {critText}\n");



      Console.WriteLine("FINAL STATUS:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine(paladin.GetInfo());
      Console.ReadKey();
    }
  }
}
