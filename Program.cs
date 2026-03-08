using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      Hunter killian = new Hunter("Киллиан - древнее зло");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{killian.GetInfo()}\n");

      Console.WriteLine($"{killian.Name} атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      killian.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = killian.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(killian.GetInfo());
      Console.ReadKey();

    }
  }
}
