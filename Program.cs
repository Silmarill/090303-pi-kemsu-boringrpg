using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      Cleric danila = new Cleric("Даня");
      
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}\n");
           
      Console.WriteLine($"{danila.Name} атакует {lancelot.Name}!");
        
      beforeHP = lancelot.HP;
      danila.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = danila.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      
      Console.WriteLine($"ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        $"======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}");

      Console.WriteLine($"Тест перегрузки:\n" +
                        $"ХП {danila.Name} уменьшено на 10\n");
      
      // перегрузка оператора -
      danila -= 10;

      Console.WriteLine($"Текущее ХП {danila.Name}: {danila.HP}\n" +
                        $"ХП {danila.Name} увеличено на 100:\n");

      // перегрузка оператора +
      danila += 100;

      Console.WriteLine($"Текущее ХП {danila.Name}: {danila.HP}\n");

      Console.WriteLine("Проверка на живучесть:");

      // перегрузка операторов true/false
      if (danila) {
        Console.WriteLine($"{danila.Name} ещё живой\n");
      }
      else {
        Console.WriteLine($"{danila.Name} вернулся в объятия богини. " +
                          $"Его боевой дух будут помнить вечно\n");
      }

      Console.WriteLine("Нанесён смертельный урон\n");

      danila -= 1000;

      if (danila) {
        Console.WriteLine($"{danila.Name} ещё живой\n");
      }
      else {
        Console.WriteLine($"{danila.Name} вернулся в объятия богини. " +
                          $"Его боевой дух будут помнить вечно\n");
      }

      Console.Write("Нажмите любую клавишу, чтобы продолжить...");
      Console.ReadKey();
    }
  }
}