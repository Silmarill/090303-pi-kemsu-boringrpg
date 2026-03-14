using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage, hil;

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

      Console.WriteLine($"{lancelot.Name} атакует {killian.Name}!");

      beforeHP = killian.HP;
      lancelot.Hit(killian);
      damage = beforeHP - killian.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("Нынешнее состояние: \n");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(killian.GetInfo());

      Console.WriteLine("Киллиан - древнее зло использует лечение \n");
      HealthPotion hilpotion = new HealthPotion(5);
      beforeHP = killian.HP;
      killian += hilpotion; 
      hil = killian.HP - beforeHP;

      Console.WriteLine($"{killian.Name} лечится на {hil} \n");
      
      if (killian) { 
        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
        Console.WriteLine("======================");
        Console.WriteLine(lancelot.GetInfo());
        Console.WriteLine(killian.GetInfo());
        Console.ReadKey();
      }

    }
  }
}
