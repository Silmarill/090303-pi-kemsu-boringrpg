using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      Druid cedric = new Druid("Кедрик Зелёный");
      Druid morgan = new Druid("Морган Лесная");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{cedric.GetInfo()}\n" +
                        $"{morgan.GetInfo()}\n");

      Console.WriteLine($"{cedric.Name} атакует {morgan.Name}!");

      beforeHP = morgan.HP;
      cedric.Hit(morgan);
      damage = beforeHP - morgan.HP;

      critText = cedric.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(cedric.GetInfo());
      Console.WriteLine(morgan.GetInfo());

      Console.WriteLine("\n=== Демонстрация операторов + и - ===");
      cedric = cedric + 10;
      Console.WriteLine($"После +10 HP: {cedric.GetInfo()}");
      cedric = cedric - 5;
      Console.WriteLine($"После -5 HP: {cedric.GetInfo()}");

      if (cedric)
      {
        Console.WriteLine($"{cedric.Name} жив и готов к бою!");
      }

      Console.ReadKey();
    }
  }
}