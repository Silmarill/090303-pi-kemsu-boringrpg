using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      HunterClass amogus = new HunterClass("Амогус Гус");

            Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                              $"==================\n" +
                              $"{lancelot.GetInfo()}\n" +
                              $"{amogus.GetInfo()}\n");
           
      Console.WriteLine($"{amogus.Name} атакует {lancelot.Name}");

      beforeHP = lancelot.HP;
      amogus.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = amogus.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(amogus.GetInfo());
      Console.ReadKey();
    }
  }
}
