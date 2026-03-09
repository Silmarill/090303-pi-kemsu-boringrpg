using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Hunter Hunter = new Hunter("Ланселот Ловкий");
      Hunter artur =    new Hunter("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{Hunter.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      Console.WriteLine($"\nВТОРОЙ РАУНД.");

      Console.WriteLine($"{artur.Name} атакует {Hunter.Name}!");

      beforeHP = Hunter.HP;
      artur.Hit(Hunter);
      damage = beforeHP - artur.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(Hunter.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      Console.WriteLine($"\nТРЕТИЙ РАУНД.");

      Console.WriteLine($"{Hunter.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      Hunter.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = Hunter.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(Hunter.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();



    }
  }
}
