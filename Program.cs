using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      Monk shiYan = new Monk("Ши Янь");
      Monk jackieChan = new Monk("Джеки Чан");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{shiYan.GetInfo()}\n" +
                        $"{jackieChan.GetInfo()}\n");

      for (int i = 1; i <= 4; i++)
      {
        Console.WriteLine($"\n--- Раунд {i} ---");
        Console.WriteLine($"{shiYan.Name} атакует {jackieChan.Name}!");

        beforeHP = jackieChan.HP;
        shiYan.Hit(jackieChan);
        damage = beforeHP - jackieChan.HP;

        critText = shiYan.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";
        Console.WriteLine($"Нанесено {damage} урона{critText}");
      }

      Console.WriteLine("\nИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(shiYan.GetInfo());
      Console.WriteLine(jackieChan.GetInfo());

      Console.WriteLine($"\n--- Демонстрация операторов ---");
      Console.WriteLine($"Здоровье {jackieChan.Name} до лечения: {jackieChan.HP}");
      jackieChan = jackieChan + 10;
      Console.WriteLine($"Здоровье {jackieChan.Name} после лечения (+10): {jackieChan.HP}");
      jackieChan = jackieChan - 5;
      Console.WriteLine($"Здоровье {jackieChan.Name} после урона (-5): {jackieChan.HP}");

      if (jackieChan)
      {
        Console.WriteLine($"{jackieChan.Name} жив и здоров (HP > 0).");
      }
      else
      {
        Console.WriteLine($"{jackieChan.Name} повержен (HP <= 0).");
      }

      Console.ReadKey();
    }
  }
}