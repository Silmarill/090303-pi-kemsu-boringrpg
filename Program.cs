using System;
using System.Security.Cryptography;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critTextLancelot, critTextInkoromi;
      int beforeHPInkoromi, damageLancelot, beforeHPLancelot, damageInkoromi;
      
      DummyClass lancelot = new DummyClass("Lancelot the Nimble");
      DummyClass artur =    new DummyClass("Arthur Pendragon");
      Archer archer = new Archer("inkoromi21");
            
      Console.WriteLine($"THE BEGINNING OF THE BATTLE. Initial state: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n" +
                        $"{archer.GetInfo()}\n");

      Console.WriteLine($"{lancelot.Name} attacks {archer.Name}!");

      beforeHPInkoromi = archer.HP;
      lancelot.Hit(archer);
      damageLancelot = beforeHPInkoromi - archer.HP;

      critTextLancelot = lancelot.LastHitWasCrit ? " - CRITICAL HIT!" : "";

      Console.WriteLine($"Damage dealt {damageLancelot} {critTextLancelot}\n");

      Console.WriteLine($"{archer.Name} attacks {lancelot.Name}!");

      beforeHPLancelot = lancelot.HP;
      archer.Hit(lancelot);
      damageInkoromi = beforeHPLancelot - lancelot.HP;

      critTextInkoromi = archer.LastHitWasCrit ? " - CRITICAL HIT!" : "";

      Console.WriteLine($"Damage dealt {damageInkoromi} {critTextInkoromi}\n");

      Console.WriteLine("FINAL STATE:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine(archer.GetInfo());
      Console.ReadKey();
    }
  }
}
